set shell := ["sh", "-c"]
set windows-shell := ["pwsh.exe", "-c"]

alias b := build
alias c := copy

export CONTENT_DIRECTORY := "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Content Warning"
export FRAMEWORK := "net472"
export RELEASE_TARGET := "Debug"
export PROJECT_NAME := "ViralTremors"

current_directory := invocation_directory()
binary_directory := current_directory / PROJECT_NAME / "bin"
built_files_directory := binary_directory / RELEASE_TARGET / FRAMEWORK
release_directory := binary_directory / "Release" / FRAMEWORK

bepinex_plugin_directory := CONTENT_DIRECTORY / "BepInEx" / "plugins"

version := `git cliff --unreleased --bump --context | jq -r .[0].version`
unfucked_version := replace(version, "v", "")

# Build the project
build *FLAGS:
    dotnet build {{FLAGS}}

# Packages the files for Thunderstore
package: (build "-c Release")
    git cliff --unreleased --bump --exclude-path "Thunderstore/*" --prepend .\Thunderstore\CHANGELOG.md

    mkdir "Thunderstore/BepInEx/plugins"
    rm "{{release_directory / "Assembly-CSharp.dll"}}"
    rm "{{release_directory / "Newtonsoft.Json.dll"}}"
    cp "{{release_directory / "*"}}" "Thunderstore/BepInEx/plugins/"
    jq --raw-output '.version_number = "{{trim_end(unfucked_version)}}"' "Thunderstore/manifest.json" > "Thunderstore/manifest.json.tmp"
    rm "Thunderstore/manifest.json"
    mv "Thunderstore/manifest.json.tmp" "Thunderstore/manifest.json"
    7z a {{PROJECT_NAME}}.zip "./Thunderstore/*"
    just _rm-dir-{{os_family()}} "Thunderstore/BepInEx"

# Copies over the built DLLs over to the BepInEx install
copy:
    rm "{{built_files_directory / "Assembly-CSharp.dll"}}"
    rm "{{built_files_directory / "Newtonsoft.Json.dll"}}"
    cp "{{built_files_directory / "*"}}" "{{bepinex_plugin_directory}}"

# Removes the DLL files from the BepInEx install
clean:
    rm "{{bepinex_plugin_directory / dll_file}}"
    rm "{{bepinex_plugin_directory / pdb_file}}"

_rm-dir-windows DIR:
    rm {{DIR}} -Recurse -Force -Confirm:$false
_rm-dir-unix DIR:
    rm -r {{DIR}}
