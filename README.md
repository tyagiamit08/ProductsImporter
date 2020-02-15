# Project Name : Products Importer
# Description : 
This is an application which imports products from different sources and each source provides its content to us in a different format. 
# Table of Contents:
- Installation Steps
- How to run your code / tests
- Where to find your code
- Was it your first time writing a unit test, using a particular framework, etc.?
- What would you have done differently if you had had more time?

# Installation Steps:
Go to the [GitHub repo](https://github.com/tyagiamit08/ProductsImporter)
Then follow the steps as mentioned below.
- Regarding installation, I have provided the executable file under test folder.
- So, first clone the repo using `git clone https://github.com/tyagiamit08/ProductsImporter.git`
- After the cloning is complete, open command prompt.
- Go to the test folder inside the cloned repository using cd command. For example:
	- `cd C:\Users\Amit Tyagi\Desktop\App\ProductsImporter\test`
- Then run the below commands one by one as mentioned in the requirements 
  - `import.exe capterra feed-products/capterra.yaml`
  - `import.exe softwareadvice feed-products/softwareadvice.json`
 
**Input/Output Screenshot:**

![](/images/output.png)


# How to run your code / tests
As we have already seen how this application can be run from the bash. So now let’s see how we can run the tests.
Below are the steps for the same:
- Once we are done with the cloning of the repository. Go to the src folder.
- Double click the **ProductsImporter.sln** file to open the solution in Visual Studio.
- Build the solution. Go to Build Menu and click on Build Solution.
- Right click on the **ProductsImporter.BL.Tests** project and click on Run Tests option.
- This will run all the tests in the project and results will be displayed in the Test Explorer.

**Test Explorer Screenshot:**

![](/images/testResults.png)

# Where to find your code
After cloning the repository, entire code can be found in the src folder.

# Was it your first time writing a unit test, using a particular framework, etc.?
No, this was not the first time.

# What would you have done differently if you had had more time?
Below are some of the things that I would have done if I had more time.
- I would write some more tests.
- As we don’t need to save any data in the database and as mentioned *"just provide some dummy classes that echo what they are doing”*, I have written few entities. But I think I would love to implement the repository pattern with unit of work.

