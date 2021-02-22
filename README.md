# .NET 5 API Boilerplate

Run init.sh to rename to your project name.

```bash
./init.sh MyProjectName
```

After this, the folder will be your solution folder.

## Add permissions to sh files

You have to add permissions to the sh files in order to be executables in azure pipelines:

```bash
git update-index --chmod=+x build.sh
```

### Not working on zsh

For some reason it doesn't work on zsh. If you are using on zsh run:

```bash
 exec bash 
```

and then run the initialize it again.
