# WSLXAppLaunch

Small utility for WSL 2 to launch X11 Applications seamlessly without opening bash.

## Installation

To setup the WSL part run this command:

`sh -c "$(curl -fsSL https://raw.githubusercontent.com/SirJson/WSLXAppLaunch/master/wsl-setup.sh)"`

It will download the shell script `exec-x11wsl` to `/usr/local/bin` and mark it executable. It will also make sure you have `dbus-x11` installed and `uuidgen` is working.

## Usage

```
WSLXAppLaunch [Name of X11 Application]
```

Example:

```
WSLXAppLaunch konsole
```

You can also use `exec-x11wsl` from within WSL 2 to launch X11 applications. The syntax stays the same.


### Caveats

This is only tested with the proprietary X410 Server. WSLXAppLaunch also tries to launch X410 if it's not already running. But I think with a few small modifications this could also work with VcXsrv because the heavy lifting is done by the `exec-x11wsl` script.