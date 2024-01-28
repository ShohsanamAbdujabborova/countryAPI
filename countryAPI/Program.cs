using countryAPI.ConsoleUI;
MainMenu main = new MainMenu();

// Call the GetDataAsync method
main.GetDataAsync().Wait();

main.Display();
