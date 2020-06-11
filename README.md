<img src="/Images/alphametrixlogo.png"  width="238" height="102">

## Team Members
* Lachezar Bonchev - [GitLab](https://gitlab.com/lachezar.bonchev)
* Yoanna Gicheva - [GitLab](https://gitlab.com/yoanna.gicheva)

# AlphaMetrixForms

A forms website where users can **create**, **share** and **review** the answers.
Each form consists of three types of questions: text question, options question and a document question.

# Contents

- [Technologies](#technologies)
- [Project Description](#project-description)
- [Main functionalities](#main-functionalities)
    - [Public](#public)
    - [Private](#private)
- [Features](#features)
- [Database](#database)



# Technologies
![](/Images/git-technologies.png)

## Project description
### Areas
* **Private** - available for authorized and authenticated users 
* **Public** -  accessible without authentication

### Private
* A user is able to create, modify and share a form. He can view all of the submitted responses to his forms in chronological order.

### Main functionalities
#### Create form
Each type of question is being added dynamically through a **single ajax request**. 

![Alt text](/Images/textquestion.png)
![Alt text](/Images/optionquestion.png)

#### Azure Blob Storage 
Azure Blob Storage is being used **as a binary data reserve**.

![](/Images/azureblob.png)

#### Validations and modals
In the process of creation each form should consist of **at least one question**. Each input field is subject to **server validation**.
On successful submit attempt "Success alert" is being displayed.

![](/Images/success.png)

#### View answers
Every user is able to **view the answers** of his forms and **download** all of the files submitted from the respondent.

![Alt text](/Images/download.png)

### Public
* Home page, Contact with us page and Public forms page may be accessed. Answers to forms are completely anonymous.

### Main functionalities
#### Submit answer 

Based on the properties of each question a responsive view model is being rendered. 
If the answer to the text question ends up to be long text area is being displayed.

![Alt text](/Images/satisfaction.png)

Multiple choice and single option questions are being displayed as **checkbox** or a **radio button**.

A document answer may be uploaded which is to be stored in our Azure Blob Storage repository.

![Alt text](/Images/upload.png)

#### Validations and modals

Each question marked as "Required" is a subject to **validation**. The validations are based on the 
**restrictions staged in the process of creation**.

On upload of a file to the document question **file size and file number limits**
are being taken into consideration.

![Alt text](/Images/document-restriction.png)

### Features

#### Share

A form can be shared to **multiple recipients**. Each introduced **email address** is being checked and **validated client-side**.

![Alt text](/Images/share.png)

#### Search

A  **search functionality** is provided for public use. 
![Alt text](/Images/search.png)

#### Contact with us

Since **feedback** is of a great importance to us a **form for contact** with the AlphaMetrix
team can be accessed and filled from the public. 

![Alt text](/Images/contactwithus.png)


# Database
![](/Images/Database.png)



