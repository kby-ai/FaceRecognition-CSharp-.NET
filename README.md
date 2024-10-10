<p align="center">
  <a href="https://play.google.com/store/apps/dev?id=7086930298279250852" target="_blank">
    <img alt="" src="https://github-production-user-asset-6210df.s3.amazonaws.com/125717930/246971879-8ce757c3-90dc-438d-807f-3f3d29ddc064.png" width=500/>
  </a>  
</p>

#### 🤗 Hugging Face - [Here](https://huggingface.co/kby-ai) <span> <img src="https://github.com/kby-ai/.github/assets/125717930/bcf351c5-8b7a-496e-a8f9-c236eb8ad59e" style="margin: 4px; width: 36px; height: 20px"> <span/>
#### 📚 Product & Resources - [Here](https://github.com/kby-ai/Product)
#### 🛟 Help Center - [Here](https://docs.kby-ai.com)
#### 💼 KYC Verification Demo - [Here](https://github.com/kby-ai/KYC-Verification-Demo-Android)
#### 🙋‍♀️ Docker Hub - [Here](https://hub.docker.com/r/kbyai/face-recognition)

# FaceRecognition-C#
## Overview
This repository demonstrates an advanced face recognition technology by implementing face comparison based on face feature extraction and face matching algorithm.<br/>
It includes capabilities for testing face recognition in `1:N matching` scenarios.

> In this repo, we integrated `KBY-AI`'s face recognition solution into `Windows Server SDK`.<br/>
> We can customize the SDK to align with your specific requirements.

### ◾FaceSDK(Server) Details
  | Face Liveness Detection      | 🔽 Face Recognition |
  |------------------|------------------|
  | Face Detection        | <b>Face Detection</b>    |
  | Face Liveness Detection        | <b>Face Recognition(Face Matching or Face Comparison)</b>    |
  | Pose Estimation        | <b>Pose Estimation    |
  | 68 points Face Landmark Detection        | <b>68 points Face Landmark Detection</b>    |
  | Face Quality Calculation        | <b>Face Occlusion Detection</b>        |
  | Face Occlusion Detection        | <b>Face Occlusion Detection</b>        |
  | Eye Closure Detection        | <b>Eye Closure Detection</b>       |
  | Mouth Opening Check        | <b>Mouth Opening Check</b>        |

### ◾FaceSDK(Server) Product List
  | No.      | Repository | SDK Details |
  |------------------|------------------|------------------|
  | 1        | [Face Liveness Detection - Linux](https://github.com/kby-ai/FaceLivenessDetection-Docker)    | Face Livness Detection |
  | 2        | [Face Liveness Detection - Windows](https://github.com/kby-ai/FaceLivenessDetection-Windows)    | Face Livness Detection |
  | 3        | [Face Recognition - Linux](https://github.com/kby-ai/FaceRecognition-Docker)    | Face Recognition |
  | 4        | [Face Recognition - Windows](https://github.com/kby-ai/FaceRecognition-Windows)    | Face Recognition |
  | ➡️        | <b>[Face Recognition - C#](https://github.com/kby-ai/FaceRecognition-CSharp-.NET)</b>    | <b>Face Recognition</b> |
  

> To get `Face SDK(mobile)`, please visit products [here](https://github.com/kby-ai/Product):<br/>

## Screenshots

<p float="left">
  <img src="https://github.com/user-attachments/assets/75025b62-c1aa-4451-a0dd-d5e660057f2c" width=600/>
  <img src="https://github.com/user-attachments/assets/838768ac-48df-41e4-8020-0aafc2b3d70e" width=300/>
</p>

## SDK License

This project uses `KBY-AI`'s `Face Recognition Server SDK`, which requires a license per machine.

- To request the license, please provide us with the `machine code` obtained from the `getMachineCode` function.

- Ensure you copy the `license.txt` file to the `bin/x64/Debug` folder, as shown in the image below:
![image](https://github.com/user-attachments/assets/f3573d88-12c2-4d1f-8fcb-1d202be7e132)


#### Please contact us:
🧙`Email:` contact@kby-ai.com</br>
🧙`Telegram:` [@kbyai](https://t.me/kbyai)</br>
🧙`WhatsApp:` [+19092802609](https://wa.me/+19092802609)</br>
🧙`Skype:` [live:.cid.66e2522354b1049b](https://join.skype.com/invite/OffY2r1NUFev)</br>
🧙`Facebook:` https://www.facebook.com/KBYAI</br>

## About SDK

### 1. Initializing the SDK

- Step One

  First, obtain the `machine code` for activation and request a license based on the `machine code`.
  ```c#
  textBoxMachineCode.Text = FaceSDK.GetMachineCode();
  ```
  
- Step Two

  Next, activate the SDK using the received license.
  ```c#
  int ret = FaceSDK.SetActivation(license);
  ```  
  If activation is successful, the return value will be `SDK_SUCCESS`. Otherwise, an error value will be returned.

- Step Three

  After activation, call the initialization function of the SDK.
  ```c#
  ret = FaceSDK.InitSDK("data");
  ```
  The first parameter is the path to the model.

  If initialization is successful, the return value will be `SDK_SUCCESS`. Otherwise, an error value will be returned.

### 2. Enum and Structure
  - SDK_ERROR
  
    This enumeration represents the return value of the `initSDK` and `setActivation` functions.

    | Feature| Value | Name |
    |------------------|------------------|------------------|
    | Successful activation or initialization        | 0    | SDK_SUCCESS |
    | License key error        | -1    | SDK_LICENSE_KEY_ERROR |
    | AppID error (Not used in Server SDK)       | -2    | SDK_LICENSE_APPID_ERROR |
    | License expiration        | -3    | SDK_LICENSE_EXPIRED |
    | Not activated      | -4    | SDK_NO_ACTIVATED |
    | Failed to initialize SDK       | -5    | SDK_INIT_ERROR |

- FaceBox
  
    This structure represents the output of the face detection function.

    | Feature| Type | Name |
    |------------------|------------------|------------------|
    | Face rectangle        | int    | x1, y1, x2, y2 |
    | Face angles (-45 ~ 45)        | float    | yaw, roll, pitch |
    | Face quality (0 ~ 1)        | float    | face_quality |
    | Face luminance (0 ~ 255)       | float    | face_luminance |
    | Eye distance (pixels)       | float    | eye_dist |
    | Eye closure (0 ~ 1)       | float    | left_eye_closed, right_eye_closed |
    | Face occlusion (0 ~ 1)       | float    | face_occlusion |
    | Mouth opening (0 ~ 1)       | float    | mouth_opened |
    | 68 points facial landmark        | float [68 * 2]    | landmarks_68 |
    | Face templates        | unsigned char [2048]    | templates |
  
    > 68 points facial landmark
    
    <img src="https://user-images.githubusercontent.com/125717930/235560305-ee1b6a39-5dab-4832-a214-732c379cabfd.png" width=500/>

### 3. APIs
  Please refer to `FaceSDK.cs`, where all APIs are implemented.
  - Face Detection
  
    The `Face SDK` provides a single API for detecting faces, determining `face orientation` (yaw, roll, pitch), assessing `face quality`, detecting `facial occlusion`, `eye closure`, `mouth opening`, and identifying `facial landmarks`.
    
    The function can be used as follows:

    ```c#
    FaceBox[] faceBoxes = new FaceBox[10];
    int faceCount = FaceSDK.FaceDetection(pixels, imgBmp.Width, imgBmp.Height, faceBoxes, 10);
    ```
    
    This function requires 5 parameters.
    * The first parameter: the byte array of the RGB image buffer.
    * The second parameter: the width of the image.
    * The third parameter: the height of the image.
    * The fourth parameter: the `FaceBox` array allocated with `maxFaceCount` for storing the detected faces.
    * The fifth parameter: the count allocated for the maximum `FaceBox` objects.

    The function returns the count of the detected face.

  - Create Template

    The SDK provides a function that enables the generation of `template`s from RGB data. These `template`s can be used for face verification between two faces.

    The function can be used as follows:

    ```c#    
    FaceSDK.TemplateExtraction(pixels, imgBmp.Width, imgBmp.Height, ref faceBoxes[0]);
    ```

    This function requires 4 parameters.
    * The first parameter: the byte array of the RGB image buffer.
    * The second parameter: the width of the image.
    * The third parameter: the height of the image.
    * The fourth parameter: the `FaceBox` object obtained from the `faceDetection` function.

    If the `template` extraction is successful, the function will return `0`. Otherwise, it will return `-1`.
    
  - Calculation similiarity

    The `FaceSDK.SimilarityCalculation` function takes a byte array of two `template`s as a parameter. 

    ```c#
    float similarity = FaceSDK.SimilarityCalculation(faceBoxes[0].templates, personList[i].Templates);
    ```

    It returns the similarity value between the two `template`s, which can be used to determine the level of likeness between the two individuals.

### 4. Thresholds
  The default thresholds are as the following below:
  https://github.com/kby-ai/FaceRecognition-CSharp-.NET/blob/0b55245a2edc2d14f3b20bd460b1a2d1cb678f17/FaceRecognition/Form1.cs#L25-L26

