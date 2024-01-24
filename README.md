**Gourmet Game**


**Details**

A game implemented using .NET Windows Forms

A Tree structure is used, implemented in the class Node.cs

Whenever a new answer and question is learned, the game will update the decision tree with the new question in the proper place, which is: before the last question

The classes "Prompt" and "CenteredMessageBox" were created to ensure the dialogs are prompted in the position desired, which is: centered at the parent with a AutoSize property.

In my implementation, both questions like "is it sweet?" and guessess "is it lasagna?" are treated as the same structure. Only difference is the guessess don't have follow up questions, so a Yes means victory and a no means we need to ask the user for a new answer, and for a question that makes it differ from the current answer.

**Running the project** 

The game requires .NETFramework Version=v4.7.2 and Windows.

To run the game, Open the repo in Visual Studio IDE and run the project (F5)

Thanks a lot!

David


**Screenshots**

Here are a few screentshots to give you a taste of what the game is like

![image](https://github.com/davidchazanas/GourmetGame/assets/30768299/5810bf8f-50e5-4f1e-89ee-863bd07fb9bc)

![image](https://github.com/davidchazanas/GourmetGame/assets/30768299/b09d2e6e-db3f-41a7-a041-5e1adc36f4a6)

![image](https://github.com/davidchazanas/GourmetGame/assets/30768299/e29df8ae-e956-49e5-aa31-9fdf73a736ce)

![image](https://github.com/davidchazanas/GourmetGame/assets/30768299/b92cc6e3-ed9f-4c4f-ab11-329a822bc7e1)


![image](https://github.com/davidchazanas/GourmetGame/assets/30768299/a1013242-c005-43d2-89dd-14c4844cdb36)


**Suggestions**

A suggestion to improve the game experience is to sanitize empty inputs. The original game accepts them, and so does this one, but "nulls" and "emptys" could be discarded

