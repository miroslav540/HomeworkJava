using animals.commands;
using animals.controller;
using animals.view;

View view = new View();
UICommands uICommands = new UICommands(view);
Controller controller = new Controller(view, uICommands);

controller.Execute();