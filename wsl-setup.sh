#!/bin/bash

sudo apt install dbus-x11
sudo dbus-uuidgen --ensure
bash -c 'sudo wget https://gist.githubusercontent.com/SirJson/cab30feb7b7b83b087b45e0797103aa7/raw/7371c17a1dcb56ad2c9e8f0a8ca85f07dc580111/exec-x11wsl -O /usr/local/bin/exec-x11wsl && sudo chmod +x /usr/local/bin/exec-x11wsl'
echo "Ready"