using System;
using System.Collections.Generic;
using Cards;
using KlasUitwerking;

var model = new Model();
IGameUI gameUI = new ConsoleGameUI();
var viewModel = new ViewModel(model, gameUI);

viewModel.Run();


