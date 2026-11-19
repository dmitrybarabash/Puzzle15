# Puzzle15 Game

**Puzzle15 Game** is a demo project that is written in .NET 11 and illustrates working with:

#### .NET GUI frameworks:

 - Windows Forms with MVP pattern
 - WPF without MVVM pattern
 - WPF with MVVM pattern

#### Unit testing framework:
 - NUnit

Unit tests cover the common domain model, the Windows Forms presenters and the WPF MVVM view models.
The WPF project without MVVM has no unit tests: its game logic lives in the window code-behind
and can be checked only through the UI. This is one of the reasons to use the MVP or MVVM pattern.
