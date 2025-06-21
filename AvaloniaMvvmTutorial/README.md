# Avalonia MVVM C# Cross-Platform Tutorial: Student Management App

This repository contains a C# application built with Avalonia UI and the Model-View-ViewModel (MVVM) pattern, structured for cross-platform deployment (Desktop, Browser/WebAssembly, Android, iOS).

The application allows users to:
*   View a list of students with their names and grades.
*   Add new students to the list.

This project demonstrates how to structure an Avalonia application for multiple platforms using a shared core project for UI logic (Views, ViewModels) and platform-specific head projects.

## Project Structure

The solution (`AvaloniaMvvmTutorial.sln`) is organized as follows:

*   **AvaloniaMvvmTutorial.Shared/**: A .NET Standard project containing the shared code:
    *   `Models/`: Data models (e.g., `Student.cs`).
    *   `ViewModels/`: ViewModels (e.g., `MainWindowViewModel.cs`, `StudentViewModel.cs`, `ViewModelBase.cs`).
    *   `Views/`: Avalonia Views (AXAML files like `MainView.axaml`, `MainWindow.axaml`) and their code-behind. `MainView.axaml` contains the primary student management UI. `MainWindow.axaml` acts as the shell for the desktop application.
    *   `App.axaml` & `App.axaml.cs`: The main Avalonia application class, handling initialization and lifetime events.
    *   `ViewLocator.cs`: Maps ViewModels to Views.
*   **AvaloniaMvvmTutorial.Desktop/**: Targets .NET desktop (Windows, macOS, Linux). Contains the entry point (`Program.cs`) for the desktop application.
*   **AvaloniaMvvmTutorial.Browser/**: Targets WebAssembly to run in modern web browsers. Contains the entry point (`Program.cs`) for the browser application.
*   **AvaloniaMvvmTutorial.Android/**: Targets Android. Contains the Android-specific entry point (`MainActivity.cs`) and platform configurations.
*   **AvaloniaMvvmTutorial.iOS/**: Targets iOS. Contains the iOS-specific entry point (`AppDelegate.cs`, `Main.cs`) and platform configurations.
*   `Directory.Packages.props`: Centralizes NuGet package versions across all projects.

## Core MVVM Concepts

(This section would be similar to the previous README, explaining Model, View, ViewModel, Data Binding, and INotifyPropertyChanged/ObservableObject. For brevity in this step, I'll assume the user can refer to standard MVVM explanations if needed, or I can expand this later if requested.)

## Building and Running the Application

**Prerequisites**:
*   .NET SDK (version 8.0 or later).
*   Appropriate .NET workloads for desired platforms (see below).

**General Build Steps**:
1.  Clone the repository.
2.  Open a terminal in the `AvaloniaMvvmTutorial` root directory.
3.  Restore .NET workloads if prompted by build errors:
    ```bash
    dotnet workload restore
    ```
    (Specifically, `android` and potentially `wasi-experimental` for mobile/web targets might be needed. `ios` workload is for macOS environments.)

**Platform-Specific Instructions**:

### 1. Desktop (Windows, macOS, Linux)

*   **Build**:
    ```bash
    dotnet build AvaloniaMvvmTutorial.Desktop/AvaloniaMvvmTutorial.Desktop.csproj
    ```
*   **Run**:
    ```bash
    dotnet run --project AvaloniaMvvmTutorial.Desktop/AvaloniaMvvmTutorial.Desktop.csproj
    ```
    *Note*: In headless environments (like some CI/CD systems or remote terminals), the application might fail to launch a visible window due to missing display servers (e.g., "XOpenDisplay failed" on Linux). The build success and an attempt to launch indicate the application is correctly compiled.

### 2. Browser (WebAssembly)

*   **Build**:
    ```bash
    dotnet build AvaloniaMvvmTutorial.Browser/AvaloniaMvvmTutorial.Browser.csproj
    ```
*   **Run**:
    ```bash
    dotnet run --project AvaloniaMvvmTutorial.Browser/AvaloniaMvvmTutorial.Browser.csproj
    ```
    This will start a local development web server (e.g., on `http://localhost:5000` or similar). Open the provided URL in a web browser to see the application.

### 3. Android

*   **Prerequisites**:
    *   .NET Android workload: `dotnet workload install android`
    *   A full **Android SDK** installation (including platform tools, build tools for a specific API level, e.g., API 34). The path to this SDK must be discoverable by the .NET build system, often via the `ANDROID_SDK_ROOT` or `ANDROID_HOME` environment variables, or by setting the `AndroidSdkDirectory` MSBuild property.
    *   Java Development Kit (JDK), often bundled with Android Studio or installable separately.
*   **Build**:
    ```bash
    dotnet build AvaloniaMvvmTutorial.Android/AvaloniaMvvmTutorial.Android.csproj
    ```
    *Limitation*: Building the Android project in an environment without a properly configured external Android SDK will fail (error XA5300). The project structure is provided, but a full Android SDK setup is required.
*   **Run**: Requires an Android emulator or a connected Android device. Deployment is typically handled via Visual Studio or `dotnet publish` with specific properties.

### 4. iOS

*   **Prerequisites**:
    *   A **macOS environment** with Xcode installed.
    *   .NET iOS workload installed on macOS: `dotnet workload install ios`
*   **Build**:
    ```bash
    dotnet build AvaloniaMvvmTutorial.iOS/AvaloniaMvvmTutorial.iOS.csproj
    ```
    *Limitation*: Building the iOS project is **not possible** on non-macOS systems (like Linux or Windows). The .NET iOS workload on these platforms does not include the necessary Apple SDKs. The project structure is provided for completeness and for developers working on macOS.
*   **Run**: Requires an iOS simulator (via Xcode) or a connected iOS device. Deployment is typically handled via Visual Studio for Mac or Xcode.

This tutorial provides a basic structure for a cross-platform Avalonia MVVM application. Further development would involve platform-specific considerations, more complex UI interactions, and potentially native integrations if needed.
Happy Coding!
