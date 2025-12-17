# 📘 Reusable Video Panel UI Submodule (Unity)

A fully **modular**, **drag-and-drop**, and **workflow-agnostic** video UI submodule for Unity.

This package enhances the reusable media system by adding **video support**, allowing applications to display and play **assembly / disassembly / training videos** through a clean, scalable UI.

The module supports:

* Dynamic video lists loaded from JSON
* Thumbnail-based video selection
* A reusable video player with essential controls
* Scrollable, responsive layouts

Suitable for **AR/VR workflows**, **training modules**, **enterprise apps**, or **any Unity system** that requires in-app video playback.

This module is designed to be **independent**, **clean**, and **easy to integrate** into any Unity project.

---

# 📁 Folder Overview

```
Assets/
│
├── Prefabs/
│   └── VideoItem.prefab
│
├── Resources/
│   └── sample_videos/
│
├── Scenes/
│   └── Demo_Reusable_VideoPanel.unity
│
├── Scripts/
│   ├── Data/
│   │   └── VideoData.cs
│   │
│   ├── UI/
│   │   ├── VideoItemUI.cs
│   │   ├── VideoListController.cs
│   │   └── VideoPlayerController.cs
│   │
│   └── MediaController.cs
│
├── Settings/
│
├── StreamingAssets/
│   └── Thumbnails/
│       ├── video1.png
│       ├── video2.png
│       ├── video3.png
│       └── video4.png
│
├── TextMesh Pro/
│
├── Texture/
│
├── TutorialInfo/
│
├── UI/
│
├── InputSystem_Actions.inputactions
│
├── Readme/
│
└── Packages/

```

---

# 🌟 Key Features

### ✔ Modular & Reusable

Drop the prefabs into any Unity Canvas and call the API.
No dependency on `ProcedureController` or app-specific logic.

### ✔ Dynamic Video List

* Loads videos from JSON (or Resources for demo)
* Automatically creates video tiles
* Supports empty and multi-video scenarios

### ✔ Thumbnail-Based Video Selection

* Each video tile displays a thumbnail
* Thumbnails can be loaded via URL
* Supports `StreamingAssets` (Android-safe)

### ✔ Reusable Video Player

Includes essential playback controls:

* Play / Pause
* Seek slider
* Close button
* Fullscreen toggle
* Minimize / restore

### ✔ Mobile-Friendly & Responsive

Designed for **touch**, **tablets**, **AR**, **VR**, and **small-screen devices**.

---

# 🧩 Components in Detail

## 1️⃣ VideoListController.cs

Controls the **video list panel** and manages dynamic item creation.

### Responsibilities

* Parse video metadata
* Instantiate video tiles dynamically
* Handle empty list scenarios
* Control scrolling behavior

### Public API

```csharp
void PopulateVideos(List<VideoItemData> videos);
void ClearList();
```

When the list is empty, a **“No Videos Available”** message is displayed automatically.

---

## 2️⃣ VideoItemUI.cs

Controls a **single video tile** inside the list.

### Responsibilities

* Display title and description
* Load thumbnail image dynamically
* Handle Play button click
* Forward video URL to player

### Key Features

* Thumbnail loading via URL
* Works with `StreamingAssets`
* Fully reusable tile prefab

---

## 3️⃣ VideoPlayerController.cs

The **main video player controller**.

### Responsibilities

* Play video from URL
* Control playback state
* Handle seek slider
* Switch Play / Pause icons
* Manage fullscreen & minimize modes
* Close and reset player

### Supported Controls

* ▶ Play / ⏸ Pause
* Seek / scrub slider
* Close
* Fullscreen
* Minimize

---

## 4️⃣ VideoItemData.cs

Represents a single video entry.

### Fields

```csharp
public string title;         // Video title
public string description;   // Short description
public string videoUrl;      // Video URL or streaming path
public string thumbnailUrl;  // Thumbnail image path / URL
```

---

## 5️⃣ VideoListData.cs (Optional Wrapper)

Used when loading JSON files.

```csharp
public List<VideoItemData> videos;
```

---

# 🧾 Sample JSON Structure

```json
{
  "videos": [
    {
      "title": "Assembly Procedure",
      "description": "Step-by-step assembly guide",
      "videoUrl": "https://example.com/assembly.mp4",
      "thumbnailUrl": "thumbnails/assembly.jpg"
    },
    {
      "title": "Disassembly Procedure",
      "description": "Safe disassembly process",
      "videoUrl": "https://example.com/disassembly.mp4",
      "thumbnailUrl": "thumbnails/disassembly.jpg"
    }
  ]
}
```

---

# 🎬 Video Panel Usage

### Populate video list

```csharp
VideoListController.Instance.PopulateVideos(videoData.videos);
```

---

### Play a video (handled internally)

```csharp
VideoPlayerController.Instance.PlayVideo(videoUrl);
```

---

# 🔧 Integration Steps

## **Step 1 — Add Prefabs to Canvas**

Drag the following prefabs into any Canvas:

* `VideoListPanel.prefab`
* `VideoPlayerPanel.prefab`

Keep them **enabled** but visually hidden (handled by scripts).

---

## **Step 2 — Ensure Singleton Instances Exist**

The following controllers use singleton patterns:

* `VideoListController`
* `VideoPlayerController`

Only **one instance** of each is required in the scene.

---

## **Step 3 — Load Video Data**

You may load video data from:

* JSON file
* Resources (demo)
* Server API
* Addressables (future-ready)

---

## **Step 4 — Use Public APIs**

```csharp
VideoListController.Instance.PopulateVideos(videoList);
```

The player opens automatically when a video tile is clicked.

---

# 🎥 Demo Scene

`Demo_Reusable_VideoPanel.unity`

Demonstrates:

* Video list loading
* Thumbnail rendering
* Playback controls
* Seek functionality
* Fullscreen & minimize behavior

Ideal for onboarding and validation.

---

# 🧠 Design Philosophy

### ✔ UI separated from logic

The UI module does not depend on business logic or workflows.

### ✔ Data-driven

Video content is controlled entirely via metadata.

### ✔ Callback-free player

Simple playback without workflow coupling.

### ✔ Zero dependencies

Works seamlessly with:

* AR Foundation
* VR
* Mobile
* Desktop
* Enterprise apps

### ✔ Extensible

Easily add:

* Analytics
* Playback history
* Download support
* Addressables streaming

---

# 🏁 Conclusion

The **Reusable Video Panel Submodule** provides:

✔ Dynamic video list UI
✔ Thumbnail-based selection
✔ Reusable video player
✔ Playback controls & seek support
✔ Fullscreen & minimize options
✔ JSON-driven content
✔ Mobile & AR/VR friendly design
✔ Easy integration into any Unity workflow
