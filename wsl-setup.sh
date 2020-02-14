#!/bin/bash

sudo apt install dbus-x11
sudo dbus-uuidgen --ensure
bash -c 'sudo wget https://raw.githubusercontent.com/SirJson/WSLX11AppLaunch/master/exec-x11wsl -O /usr/local/bin/exec-x11wsl && sudo chmod +x /usr/local/bin/exec-x11wsl'
echo "Ready"
