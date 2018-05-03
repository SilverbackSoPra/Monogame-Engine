git submodule deinit -f -- "Monogame Engine/Engine"
RD /S /Q ".git/modules/Engine"
git rm -f "Monogame Engine/Engine"
git submodule add --name "Engine" https://github.com/SilverbackSoPra/Engine.git "Monogame Engine/Engine"
git submodule init
git submodule deinit -f -- "Monogame Engine/Content/Shader"
RD /S /Q ".git/modules/Shader"
git rm -f "Monogame Engine/Content/Shader"
git submodule add --name "Shader" https://github.com/SilverbackSoPra/Shader.git "Monogame Engine/Content/Shader"
git submodule init