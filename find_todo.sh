#!/bin/bash

# This script reads the directory passed as $1 argument or the current one to find all markdown files and search for a %%TODO%% tag

directory="${1:-.}"


find "$directory" -type f -name "*.md" | while read -r file; do
    if grep -q "%%TODO%%" "$file"; then
        echo "TODO found in: $file"
    fi
done
