
# Documentation

Here lies documentation for this project

## Directory Structure
* `champion_documents/`: Contains the champion document for each team member
* `class_and_sequence_diagrams/`: Contains the Class Diagrams, Sequence Diagrams, and Gantt Timelines for week 1

## Coding Style and Conventions

This project uses the official C# coding conventions with Allman Style indentation.
* [Official C# coding conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
* [Allman Style](https://en.wikipedia.org/wiki/Indentation_style#Allman_style)
## Team Members
| Member           | Role                      |
|------------------|---------------------------|
| Alex McNurlin    | Team Lead 1               |
| Josue Espinosa   | Team Lead 2               |
| Zane Durkin      | Quality Assurance Manager |
| Hayden Lepla     | Project Manager           |
| Tori Overholtzer | Software Architect        |
| Simon Barnes     | Documentation Specialist  |
| Jorge Olivas     | Systems Analyst           |

## Git Branch conventions
The purpose of this section is to provide a clear and consistent outline for management of branches in git. The methods presented here are intended to mimic the development model required in many professional settings.

### The Master Branch
The `master` branch should represent the most stable version of the code available. No users can push commits directly to the `master`. Instead, a user must create a new branch, commit changes to that branch, then submit a pull request. At least one user must approve the pull request before it can be merged. This will be enforced with GitHub’s built in branch management tools.

### Feature branches
Feature branches represent most work done. Feature branches will typically branch directly from `master` and be merged into `master` when complete. They should follow the below naming convention
* `feature/1234-add_new_feature` where 1234 is an associated issue number.
* `feature/add_new_feature` if no issue exists.

Example for creating a new branch:
`git checkout -b feature/11234-add_new_feature`

### Bugfix Branches
Bugfix branches can be created whenever necessary to fix a bug that exists in `master` or a feature branch. A bugfix branch should follow the following naming convention.
* `bugfix/1234-short_description_of_bug` where 1234 is an associated issue number.
* `bugfix/short_description_of_bug` if no issue exists.

### Additional Branches
Not all work will be on a feature or bugfix. Any other work should be done in a branch using the following naming convention.
* `am/short_description_of_work` where `am` are the initials of the user creating the branch.

### Notes
* Users should make sure to keep their feature branch up to date with `master` whenever a change is made to `master`. This can be done with `git merge master`. This will avoid merge conflicts.
* A new git branch can be created with the command `git checkout -b my_new_branch` or `git branch my_new_branch` followed by `git checkout my_new_branch`
