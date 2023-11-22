#!/bin/bash

sed -i 's/[^,]*,//' "$@"
sed -i 's/,.*//' "$@"
sed -i 's/"//g' "$@"
