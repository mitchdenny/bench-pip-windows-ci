# Steve Dower suggested that using a venv might make things faster on Azure,
# so we'll try it both ways.
# https://twitter.com/zooba/status/1078548597195497472
param([switch] $UseVenv, [switch]$CacheVenv)

Set-PSDebug -Trace 1

if ($CacheVenv) {
    python -m venv myenv
    myenv\Scripts\activate
}

if ($UseVenv) {
    myenv\Scripts\activate
}

python -m pip install -U pip --cache-dir $BUILD_SOURCESDIRECTORY\pipcache

python --version
python -c "import struct; print(struct.calcsize('P') * 8, 'bits')"
pip --version

Measure-Command {pip install -r requirements.txt --cache-dir $BUILD_SOURCESDIRECTORY\pipcache }
pip list
