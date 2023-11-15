# Members:
| Student ID | Name                  |
|------------|-----------------------|
| 21520147   | Pham Tuan Anh         |
| 21521812   | Nguyen Thanh Thien An |

# Using CLI:
- Change directory to **WorkScheduleReminder.Testing**.
- Enter **```$ dotnet tool restore```** to install stryker locally.
- Enter **```$ dotnet dotnet-stryker```** to run stryker.

# Note:
- The **StrykerOutput** folder should be in the same directory **(WorkScheduleReminder.Testing)**.
- There is a **stryker-config.json** file at the root of **WorkScheduleReminder.Testing**.
- The test project **(WorkScheduleReminder.Testing)** includes both frontend and backend tests, so when stryker is being run, frontend tests will also be executed, which have a sample automation test using Playwright. ***Please ignore them, they are not virus, thank you***.
