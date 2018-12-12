Firebase Unity SDK
==================

The Firebase Unity SDK provides Unity packages for the following Firebase
features on *iOS* and *Android*:

| Feature                            | Unity Package                     |
|:----------------------------------:|:---------------------------------:|
| Firebase Analytics                 | FirebaseAnalytics.unitypackage    |
| Firebase Authentication            | FirebaseAuth.unitypackage         |
| Firebase Realtime Database         | FirebaseDatabase.unitypackage     |
| Firebase Dynamic Links             | FirebaseDynamicLinks.unitypackage |
| Firebase Crashlytics               | FirebaseCrashlytics.unitypackage  |
| Firebase Invites                   | FirebaseInvites.unitypackage      |
| Firebase Messaging                 | FirebaseMessaging.unitypackage    |
| Firebase Realtime Database         | FirebaseDatabase.unitypackage     |
| Firebase Remote Config             | FirebaseRemoteConfig.unitypackage |
| Firebase Storage                   | FirebaseStorage.unitypackage      |

Firebase Crashlytics EAP
------------------------

Thanks for trying out the EAP of Firebase Crashlytics for Unity! Below you'll
find instructions for how to set up and begin using Firebase Crashlytics for
Unity.

Getting Started
---------------

To get started, download `FirebaseCrashlytics.unitypackage` from the
[firebase_unity_sdk](https://dev-partners.googlesource.com/unity-firebase/+/master/firebase_unity_sdk)
directory in
[this git repository](https://dev-partners.googlesource.com/unity-firebase).
You can either clone this entire repository in order to stay up to date with
further updates, or you can download the Unity package files directly by
clicking the
["tgz"](https://dev-partners.googlesource.com/unity-firebase/+archive/master/firebase_unity_sdk.tar.gz)
link at the top of the page. There are also zip files of this repository
available on the
[zip](https://dev-partners.googlesource.com/unity-firebase/+/zip)
branch.

Setup
-----

Using the Unity package files in this repository, follow the
[SDK setup instructions](https://firebase.google.com/docs/unity/setup).

To be clear, you won't need to download the SDK from those instructions --
you'll use the Unity package files in
[this repository](https://dev-partners.googlesource.com/unity-firebase/+/master/firebase_unity_sdk)
instead.

Initialize Firebase, including Crashlytics, with the following code in your
first scene:

    Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
        var dependencyStatus = task.Result;
        if (dependencyStatus == Firebase.DependencyStatus.Available) {
            // Create and hold a reference to your FirebaseApp, i.e.
            //   app = Firebase.FirebaseApp.DefaultInstance;
            // where app is a Firebase.FirebaseApp property of your
            // application class.

            // Set a flag here indicating that Firebase is ready to use by your
            // application.
        } else {
            UnityEngine.Debug.LogError(System.String.Format(
                "Could not resolve all Firebase dependencies: {0}",
                dependencyStatus)
            );
            // Firebase Unity SDK is not safe to use here.
        }
    });

Crashlytics will initialize crash reporting in both the Unity runtime as well as
at the platform level (iOS or Android). In order to test a crash in your Unity
code, simply call a method that throws a C# exception, such as:

    private void Crash() {
      throw new System.Exception("Test Crash");
    }

It is important to note that these exceptions will not crash the app, but will
be reported as non-fatals in Crashlytics the next time the app is started.

Currently, Firebase Crashlytics for Unity only captures C# exceptions and
platform-level errors. It does not capture native (C++) crashes,
so errors from functions like `Application.ForceCrash()` will not be captured.

Enhance Crash Reports
---------------------

To give you more insight into crash reports, Crashlytics provides four logging
mechanisms right out of the box: custom keys, custom logs, user identifiers,
and caught exceptions.

## Custom Keys

Firebase Crashlytics allows you to associate a key/value pair to be sent with
your crash reports. When called multiple times, new values for existing keys
will update the value, and only the most current value will be captured when a
crash is recorded.

    Firebase.Crashlytics.Crashlytics.SetKeyValue(string key, string value);

## Custom Logs

Logged messages are associated with your crash data and are visible in the
Firebase Crashlytics dashboard when viewing a specific crash.

    Firebase.Crashlytics.Crashlytics.Log(string message);

## User Identifiers

An ID number, token, or hashed value can be used to uniquely identify the
end-user of your application without disclosing or transmitting any of their
personal information. You can also clear the value by setting it to a blank
string. This value is displayed in the Firebase dashboard when viewing a
specific crash.

    Firebase.Crashlytics.Crashlytics.SetUserId(string identifier);

Related APIs also allow you to include a name and email address:

    Firebase.Crashlytics.Crashlytics.SetUserEmail(string email);
    Firebase.Crashlytics.Crashlytics.SetUserName(string name);

## Caught Exceptions

In addition to automatically reporting your app’s crashes, Crashlytics lets you
log custom exceptions in C# using the following methods:

    Firebase.Crashlytics.Crashlytics.RecordCustomException(
            string name, string reason, StackTrace stackTrace);
    Firebase.Crashlytics.Crashlytics.RecordCustomException(
            string name, string reason, string stackTraceString);

Custom exceptions can be included in your app’s try/catch blocks:

    try {
        myMethodThatThrows();
    } catch (Exception e) {
       Crashlytics.RecordCustomException("my exception", "thrown exception", e);
       // handle your exception here!
    }

Support
-------

[Firebase Support](http://firebase.google.com/support/)

Release Notes
-------------
## Firebase Crashlytics - EAP 2
  - Overview
    - Updated Crashlytics SDK versions
      - Android: Crashlytics 2.9.5
      - iOS: Crashlytics 3.9.7, Fabric 1.7.11

## Firebase Crashlytics - EAP 1
  - Overview
    - Initial release of Unity support for Firebase Crashlytics.
