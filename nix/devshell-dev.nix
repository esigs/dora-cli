{ pkgs }:

let 
in pkgs.mkShell {
        buildInputs = [ 
		pkgs.dotnetCorePackages.sdk_9_0
		pkgs.nodejs
		pkgs.powershell
        ];


        shellHook = ''
    export APP_ENV="DEV"
    export PATH=$PWD/.nix-profile/bin:$PATH
    export PS1="[\033[1;32mNIX-ENV\033[0m $APP_ENV] $PS1"

echo "
environment:    $APP_ENV
"
    '';
    }
