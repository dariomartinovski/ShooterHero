# ShooterHero

How to commit Unity files to an existing GitHub repository:

1. Make sure you have Git installed on your machine and set up a local repository for your Unity project. If you haven't done this already, you can initialize a Git repository in your Unity project folder by running the following commands in the command line:

```bash
cd /path/to/your/unity/project/folder
git init
```

2. Create a new repository on GitHub. If you already have an existing repository, you can skip this step.

3. Link your local Git repository to the GitHub repository by adding a remote origin. Replace `<repository-url>` with the URL of your GitHub repository:

```bash
git remote add origin <repository-url>
```

4. Stage the changes you want to commit. In Unity, you can use the Unity Editor's Version Control system or use the command line.

Using the command line, you can add all the changed files by running:

```bash
git add .
```

If you want to stage specific files, replace `.` with the paths to those files.

5. Commit the changes:

```bash
git commit -m "Commit message"
```

Replace `"Commit message"` with a meaningful description of the changes you're committing.

6. Push the changes to the remote repository:

```bash
git push origin <branch-name>
```

Replace `<branch-name>` with the name of the branch you want to push the changes to, such as `main` or `master`.

After executing the `git push` command, the Unity files will be committed to your existing GitHub repository.

Note: Make sure you have the necessary permissions to push changes to the GitHub repository. If you encounter any issues, ensure you have the correct access rights and verify the repository URL.
