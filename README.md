<div align="center">
  <img src="./desktop-translator/Images/EaZy_Talk.png" width="150"/>
  <h1> EaZy Talk </h1>
</div>

EaZy Talk is a translator C# WPF application created by using the MVVM pattern.

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Features](#features)
* [Screenshots](#screenshots)
* [UML diagram](#uml-diagram)
* [Setup](#setup)
* [Usage](#usage)
* [Room for Improvement](#room-for-improvement)
* [Creator](#creator)
<!-- * [License](#license) -->


## General Information
- Translate text from foreign languages via **Google Translate API**.
- Translated sentences are saved in **SQLite** Database.
- The goal is to create a project that will be a bachelor thesis.
- I started getting in C# when time to choose a topic was came. So I decided to go in this and develop my skills.

## Technologies Used
- [Visual Studio](https://www.kunal-chowdhury.com/2015/07/download-visualstudio-2015.html) - version 2015
- [.NETFramework](https://learn.microsoft.com/pl-pl/dotnet/) - version 4.5.2
- [SQLite](https://sqlite.org/) - version 1.0.117.0
- [Google Translate API](https://cloud.google.com/translate) - version 2.0


## Features
- Automatic **from** language detection.
- Saving sentences in history.
- **Always on top** possibility.


## Screenshots
### Application look
- **Main view**
<img src="./desktop-translator/Images/Screenshots/Translate_shot.png"/>
  
- **History view**
<img src="./desktop-translator/Images/Screenshots/History_shot.png"/>

- **Options view**
<img src="./desktop-translator/Images/Screenshots/Options_shot.png"/>


## Setup
In NuGet Package Manager console

```
git clone https://github.com/Piasta/desktop-translator-lic.git

Update-Package
```
## Usage
After run, choose **to language** from **options** and type your sentence.


## Improvements

To improve:
- Auto get value from clipboard and translate when user copy text by HotKey.


## Creator
>Created by [Piasta](https://github.com/Piasta/).
