# AcPgChecker: A tool for Plagiarism Detection in Students’ Assignments and Reports
Plagiarism is one of the growing issues in academia and is always a concern in Universities and other academic institutions as this is quite common among students while submitting any assignments or reports. Teachers face difficulties in marking students’ assignments with higher degree of judgment and waste their valuable time for plagiarism detection. This has made some strong influences on learning objectives of students. This tool focuses on building an effective, simple and fast tool for plagiarism detection on text based electronic assignments to minimize this issue and to help teachers in conducting proper evaluation of assignments.

## Documentation for End-Users
---------------------------
* Download setup file from [here](https://github.com/dipongkor/PlagiarismChecker/releases/download/v1.0/PlagiarismChecker.Setup.msi)
* Install and run the application. If you run the application, you will find the following window -
![](Paper/images/plagiarism_checker.PNG)
* Select the folder that contains all the documents.
* Enter the number of word sequence for measuring similarity.
* Enter the thresold of plagiarism.
* Select the output loaction.
* Click on proceed.
* Go to the output location. You will find the plagiarism report their.

## Documentation for Contributors
* Download [Visual Studio 2019 Community Edition].(https://visualstudio.microsoft.com/downloads/)
* Install .NET 4.5 while installing Visual Studio 2019.
* Clone the repository `git clone https://github.com/dipongkor/PlagiarismChecker.git`
* Build the Solution. It will add dependencies from the [NuGet](https://www.nuget.org)
* The solution contains six projects
  - **Plagiarism.Vectoriser:** It is a class library for creating n-gram and document-term matrix. The unit tests of this library are written in **Plagiarism.Vectoriser.Tests**.
  - **PlagiarismChecker.Pdf.Parser:** This class library parses text from PDF documents. The unit tests of this library are written in **PlagiarismChecker.Pdf.Parser.Tests**.
  - **PlagiarismChecker.Ui:** It is a WPF solution which implements the UI and functionalities.
  - **Plagiarism.Setup:** It is the setup project which generates installer file. This project has a dependency with an extension named [Microsoft Visual Studio Installer Projects](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2017InstallerProjects). It is required to install this extension before running the project.