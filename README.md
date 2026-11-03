<a id="readme-top"></a>

# uGUI Workshop: Build a Character Creation Screen

<div align="center">
<a href="https://github.com/Undefined52/UnityResearchUI"></a>

> A character creation screen where participants can preview a character, change its appearance, interact with UI elements, and see simple animations.
</div>

---

## Table of Contents
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#What-Is-uGUI">uGUI background</a></li>
    <li><a href="#The-Concept-Map">uGUI concept map</a></li>
    <li><a href="#Summary">What will you do in the workshop?</a></li>
    <li><a href="#Getting-Started">Getting started for the workshop</a></li>
    <li>
      <a href="#The-Workshop"><b>__The workshop__</b></a>
      <ul>
        <li><a href="#Part-1-Canvas--Screen-Space-UI">Part 1 Canvas & Screen Space UI</a></li>
        <li><a href="#Part-2-World-Space,-Diegetic-UI--Layout">Part 2 World Space, Diegetic UI & Layout</a></li>
        <li><a href="#Part-3-Components--Custom-Components">Part 3 Components & Custom Components</a></li>
        <li><a href="#Part-4-Animations--Transitions">Part 4 Animations & Transitions</a></li>
      </ul>
    </li>
    <li><a href="#Sources">Sources</a></li>
    <li><a href="#Authors">Authors</a></li>
  </ol>
</details>


---

## What Is uGUI?
uGUI (Unity UI) is Unity’s GameObject-based system for building user interfaces in games. It has been part of Unity since 2014 and is the recommended choice for in-game (runtime) UI, such as menus, HUDs and popups.

In uGUI, every piece of UI is a normal GameObject with components on it. A button, a piece of text and a picture are all GameObjects, and the components decide how each one looks and behaves. This means you work with the same Hierarchy and Inspector as in the rest of Unity.

Everything starts with a Canvas. This is the root object that draws all the UI placed under it. The Canvas has a render mode that decides where the UI appears:
<br> <u>Screen Space</u> - Overlay: drawn flat on top of the screen.
<br> <u>Screen Space</u> - Camera: drawn at a distance in front of a camera.
<br> <u>World Space</u> - placed inside the 3D world, like any other object.

Inside the Canvas, you add components such as Text, Image, Button, Slider and Toggle. Each has a RectTransform (a position and size for UI), and the interactive ones send events when you click or change them, so you can connect them to your own scripts. An EventSystem, which Unity adds automatically, passes the clicks and typing to the UI.

uGUI is not the only UI system in Unity. IMGUI is the older system, used for editor tools, and UI Toolkit is the newer, web-style system. uGUI is well documented and IMGUI is a bit too outdated. So this workshop will focus on uGUI.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## The Concept Map

[Download the concept map (draw.io)](https://github.com/Undefined52/UnityResearchUI/blob/workshop_mess/ConceptMapUI%20.drawio)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## Summary
The workshop has four parts. Each part is one short table of steps, and each one teaches a single area of uGUI.

| Part | Topic                               | You will learn |
|---|-------------------------------------|---|
| 1 | Canvas & Screen Space UI            | What a Canvas is, how Overlay and Camera mode draw UI, HUD vs menu, draw order, using images in UI |
| 2 | World Space,  Diegetic UI  & layout | UI that exists inside the 3D world |
| 3 | Components & Custom Components      | Built-in components (Button, Slider, Toggle) and connecting them to your own scripts |
| 4 | Animations & Transitions            | Button transitions, Animator, triggering animations from UI |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## Getting Started
1. Install **Unity [VERSION]** (use exactly this version, it is also in `ProjectSettings/ProjectVersion.txt`).
2. Clone the repo: `git clone [REPO URL]`
3. Switch to the workshop branch: `git checkout [BRANCH NAME]`
4. Open Unity Hub > **Add > Add project from disk** and pick the cloned folder.
5. The first open takes a few minutes while Unity rebuilds its cache. That is normal.
6. Open the scene in `Assets/Scenes/[SCENE NAME]`.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## The Workshop
### Part 1 Canvas & Screen Space UI

> **Goal:** Build the HUD and menus of the character creation screen. You learn what a Canvas is, how uGUI displays UI on the screen, and how UI elements are organized.

| Step | What you do | What you learn |
|---|---|---|
| 1 | Right-click the Hierarchy, click **UI (Canvas) > Canvas**. Notice the **EventSystem** Unity adds. | The Canvas is the root for all uGUI elements. The EventSystem lets buttons and input fields receive clicks. |
| 2 | Check that **Render Mode** is **Screen Space - Overlay** (this is the default). | Overlay draws the UI on the screen, on top of the 3D world. |
| 3 | Right-click the Canvas > **UI > Panel**, rename it `NameForm` and stretch it over the screen. | A panel groups UI into a section. |
| 4 | Inside `NameForm`, add a title text ("What's your name?"), an **Input Field - TextMeshPro** (`NameInput`) and a **Button - TextMeshPro** (`OKButton`). Change the button label in its child **Text (TMP)**. | The parts of a menu: text, input and button. A button is a shape (parent) with a label (child). |
| 5 | Add an **Image** inside `NameForm` as a menu card. Import a PNG, set **Texture Type** to **Sprite (2D and UI)**, click **Apply**, and drag it into **Source Image**. | How to use an image in UI. Without the Sprite setting, the PNG won't fit in the slot. Use **Preserve Aspect** so it isn't stretched. |

---

### Part 2 World Space, Diegetic UI & Layout

> **Goal:** Understand how UI can exist inside the 3D world, and how to make the screen organized and adaptable.
>
> World Space is a Canvas render mode. Diegetic UI is a design concept where the interface exists as part of the game world. A world-space Canvas is one way to make it, but world-space UI is not automatically diegetic.

#### 2.1 World Space

| Step | What you do | What you learn |
|---|---|---|
| 1 | In the scene Hierarchy, open the `Room` object and click the Canvas that has the sliders in it. | Finding the Canvas you want to change. |
| 2 | In the Inspector, set the Canvas **Render Mode** to **World Space**. | There are different render modes, which change how UI is rendered. |
| 3 | Set the position to **X 0.1, Y 1.6, Z 2.4**. | A world-space Canvas has a position in the 3D world, like any other object. |
| 4 | Set the width to **200** and the height to **300**. | The size of the Canvas in UI units. |
| 5 | Set the scale to **X 0.01, Y 0.01, Z 0.01**. | A world-space Canvas starts huge, because 1 pixel = 1 unit. |
| 6 | Set the **Event Camera** to the Main Camera. | World-space UI needs a camera to receive clicks. |

> RectTransform controls position, size, anchors and pivot. Layout Groups arrange their children. Canvas Scaler scales UI for different resolutions.

#### 2.2 Layout

| Step | What you do | What you learn |
|---|---|---|
| 1 | Select the Canvas created in Part 1. On the **Canvas Scaler**, set **UI Scale Mode** to **Scale With Screen Size** (1920 x 1080). | The UI scales with the resolution to fit different screens. |
| 2 | Add a **Vertical Layout Group** to the Panel. | The group stacks its children automatically. |
| 3 | Change **Spacing** and **Padding**. | Layout replaces placing things by hand. |
| 4 | Add a **Layout Element** to one child and set a **Preferred Height**. | You can override the size of one child. |
| 5 | Set anchors on the panel using **Shift + Alt** in the preset box. | Anchors pin UI safely to the screen edges, regardless of resolution changes. |
 
---

### Part 3 Components & Custom Components

> **Goal:** Make the interface interactive and connect UI to code.
> 
> Standard components (Button, Slider, Toggle) come with Unity. Custom components are scripts you write yourself, to add behavior Unity doesn't provide. UI controls can drive game logic.

| Step | What you do | What you learn |
|---|---|---|
| 1 | Add a **Slider** and a **Text** to the Canvas. | Using the built-in uGUI components. |
| 2 | Create a script that holds a reference to the slider and the text. | Reading out built-in components and applying their values. |
| 3 | Add a listener to the slider's `onValueChanged` in `OnEnable`, and remove that listener in `OnDisable`. Update the text with the new value in the function the listener calls. | How to react to a UI event, and why you remove listeners again. |
| 4 | Put the script on an empty parent of the slider and text. Drag the slider and text onto the script's matching fields. | Wiring up the components. |
| 5 | Find out what `LabeledSlider` publishes. Find out what `ColorPicker` publishes. | How values are published, and how to tell them apart. |
| 6 | Create a script that holds a reference to the slider and a material. Apply the new color to the material to create the custom behaviour. | Reading out custom events and values, and applying them. |
| 7 | Put the color target on the player root and give it the player's shirt or pants material (or another material). | Wiring up. |
 
---

### Part 4 Animations & Transitions

> **Goal:** Make the interface respond visually to player interactions.
> 
> Button transitions are built into uGUI. Bigger animations use the Animation and Animator systems, with a button or script triggering them.
>
> In this workshop you add hover animations to the clothing on the left. The Animator and the hover detection are already in the project.

| Step | What you do | What you learn |
|---|---|---|
| 1 | Click **Window > Animation > Animator**. | How to open the Animator window. |
| 2 | Click the shirt object in one of the `RackItem`s. The Animation window asks to create a new animation. Click it and give it a name. | How to start making an animation for a GameObject. |
| 3 | Next to the preview button there is a red dot. Click it so it becomes more saturated and record mode is on. | How to enable record mode. |
| 4 | Move the white timestamp line to **0:40**. Move the shirt: the changed values are added at the position of the white line. In the Dopesheet window, keyframe dots appear at the start and at the current time. | How to use record mode and keyframes. |
| 5 | Use the play option to preview the animation. Use what you learned above to make an "appear" animation. | How to create a complete animation. |
| 6 | Make a new animation that puts the shirt back into the rack. Make sure it starts at the end position of the appear animation. Click both animations and set their **Loop Time** to false. | Making a second animation that continues from the first one. |
| 7 | Open the animation controller (`Cloths`) via **Window > Animation > Animator**. Make sure the closing animation is the **Entry** state. | Setting the default (entry) state. |
| 8 | Make transitions between the two animations with the `on hover` and `no_hover` conditions. The conditions already exist. Set the transition timing to 0. | How to transition between animations. |
| 9 | Open the opening animation and add an **event**. In this event, call **HoverHandler > Methods > onShowText** with **1** as the parameter. Do the same for the closing animation, but set the argument to **0**. | How to add animation events. |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## Sources
- Harvard University (s.d.). *Accessibility for Designers*. Digital Accessibility Services. Referenced on 29 Sept 2026. https://accessibility.huit.harvard.edu/ui-elements
- LIGHT11 (2026 Apr). *【Unity】【uGUI】CanvasのRender Modeをちゃんと理解する*. Hatena Blog. Referenced on 29 Sept 2026. https://light11.hatenadiary.com/entry/2019/04/15/232416
- Mojang Studios (s.d.). *[Home page]*. Minecraft. Referenced on 29 Sept 2026. https://www.minecraft.net/en-us
- Si (2024 Oct). *Procedural UI Elements || Unity Asset Store*. Community showcases. Referenced on 29 Sept 2026. https://discussions.unity.com/t/procedural-ui-elements-shaders/1534009
- Unity (s.d.). *Animation Integration*. Referenced on 14 Sept 2026. https://docs.unity3d.com/Packages/com.unity.ugui@2.6/manual/UIAnimationIntegration.html
- Unity (s.d.). *Interaction Components*. Referenced on 29 Sept 2026. https://docs.unity3d.com/Packages/com.unity.ugui@2.7/manual/UIInteractionComponents.html
- Unity (s.d.). *Unity UI (uGUI)*. Referenced on 29 Sept 2026. https://docs.unity3d.com/Packages/com.unity.ugui@2.6/manual/index.html
- Unity (s.d.). *Visual Components*. Referenced on 29 Sept 2026. https://docs.unity3d.com/Packages/com.unity.ugui@2.7/manual/UIVisualComponents.html
- Unity (2026 Jan). *Structure UI with UXML*. Unity Documentation. Referenced on 14 Sept 2026. https://docs.unity3d.com/6000.1/Documentation/Manual/UIE-UXML.html
- Unity (2026 Sept). *Comparison of UI systems in Unity*. Unity Documentation. Referenced on 14 Sept 2026. https://docs.unity3d.com/6000.3/Documentation/Manual/UI-system-compare.html
- Unity (2026 Sept). *IMGUI (Immediate Mode GUI)*. Unity Documentation. Referenced on 14 Sept 2026. https://docs.unity3d.com/6000.3/Documentation/Manual/ui-imgui.html
- Unity (2026 Sept). *Introduction to USS*. Unity Documentation. Referenced on 14 Sept 2026. https://docs.unity3d.com/6000.0/Documentation/Manual/UIE-about-uss.html
- Unity (2026 Sept). *UI Builder*. Unity Documentation. Referenced on 14 Sept 2026. https://docs.unity3d.com/6000.3/Documentation/Manual/UIBuilder.html
- Unity (2026 Sept). *UI Toolkit*. Unity Documentation. Referenced on 14 Sept 2026. https://docs.unity3d.com/6000.3/Documentation/Manual/UIElements.html
- Zadoienyi, D. (2026 May). *Diegetic and Non-Diegetic UI in Games: Design Principles and Use Cases*. Nasty Rodent. Referenced on 29 Sept 2026. https://nastyrodent.com/diegetic-and-non-diegetic-ui/
<p align="right">(<a href="#readme-top">back to top</a>)</p>

----

## Authors
- Morgan Atmodimedjo - Part 1
- Joris van Lier & Yehyun Lee - Part 2
- Sara Wieland - Part 3
- Renzo Straathof - Part 4

<p align="right">(<a href="#readme-top">back to top</a>)</p>
