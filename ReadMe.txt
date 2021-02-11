AllsopExam Web API Application

	This application provide sufficient endpoints so that the clients are able to easily
display all of the available products, as well as provide shopping cart functionality to which the
products can be added, removed or have quantities updated.


How to build:
1.) Open the AllsopExam.sln using the Visual Studio 2017(File Menu -> Open -> Project/Solution).
2.) Click Build Menu -> Build Solution.

The solution should build successfully and should have no error/s.


How to run:
1.) Right click the AllsopExam project, under the APP folder, then choose Set as StartUp Project.
2.) Press F5 button of your keyboard to run the project.


How to test:
For the product's availability/inventory, it is located in AllsopExam Project -> Data -> Inventory.xml (This is for temporary. Correct location is in AllsopExam.Data Project). You can add products in the Inventory.xml file.

You can test this using applications like POSTman, SoapUI and others.

Also, you can check the documentation or the Web API's help page by following steps below:
1.) After you pressed F5 button when you ran the project, browser will be automatically opened.
2.) In the addressbar, you can see the localhost url (example: localhost:1662)
3.) Add "/help" in the addressbar (example: localhost:1662/help) and then press enter.

You should see now the Web API's help page.


api/Product/GetProducts - Get available products in the inventory. Response: Available inventory products.

api/ShoppingCart/GetCart - Get the user's shopping cart. Response: User's shopping cart.

api/ShoppingCart/AddProductToCart - Add a product to the user's shopping cart. Response: Updated available inventory products and updated User's shopping cart.

api/ShoppingCart/RemoveProductInCart- Remove a product in the user's shopping cart. Response: Updated available inventory products and updated User's shopping cart.

api/ShoppingCart/AddVoucher - Add voucher in the user's shopping cart. Response: Updated User's shopping cart.

Additional Notes:
1.) You can type any integer values for UserId. For Shopping cart, AddProductToCart is the suggested first step in order to not receive errors, but you can try other methods for the first step in the shopping cart, you will only receive errors due to user cart is not yet created/existing.

2.) In response, the UserCart has SubTotalPrice and TotalPrice. SubTotalPrice is the total price of products before discounts/promos are applied. TotalPrice is the final total price of products which is the discounts/promos and voucher are already applied.


Code Layout:
The solution consists of the following folders:
1.) APP - is where the main application, AllsopExam, located.

2.) BLL - is where the business logic layer, rulings, computations, extensions are located.

3.) DAL - is where the data and contracts of the main application are located.

4.) Utilities - is where tools (like XmlSerializer) and resources are located.


Additional packages/DLL/Libraries:
Autofac - used for IOC/DI container.


Approach/Principles used:
SOLID principle
Separation of Concerns


Authors:
Jason Celestino - Initial work. Date: 2/10/2019