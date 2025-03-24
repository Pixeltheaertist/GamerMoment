# Basic C# education moment

# C# is a coding language built off of code "blocks", or callable chunks of code.

# They are ordered in a similar fashion to this:

  private void ExampleBlock
  {
    # This is an example block. The "private" means that it cannot be referenced outside of this file. The "void" symbolizes that this does not return any value. I will get more into that later.
    # Main thing to know, this chunk here will be for executing code when called with "ExampleBlock()" in another block.
  }

# There are a few different "key terms" of C#, as in, certain things that will be prevalent and appear pretty much all the time.

  # Bool: A bool (or boolean), is your basic-ass true/false, 1/0, y/n type thing. It's a variable type that pretty much can be true or false, and will be referenced as such.
    # For example, one can reference a bool (example will be named TestBool) by: "if (TestBool == true) or, the simpler way, "if (TestBool)"
    # Bools will innately be translated into a true or false by name, (TestBool is true, !TestBool is false), saving you some time.
    
  # String: A string is a line of text. They are generally formatted in a way of $"This is example text from a string". They can be used to lots of things, like UIDs, object descriptions, and saved data like usernames.

  # Float: A float is an integer. Pretty basic, it just stores numbers for later use. For example: "float ExampleFloat = 1f;" It can also store fractional numbers, such as "69.420f"
    # Note that for floats and most stored numbers, you'll add a "f" at the end to symbolize it as a float. (11f, 69.54f, 420f, etc.)
  
  # Var: a var is your basic all-rounder for storing data. It will store your states or certain code executions, such as: "var ExampleVar = ExampleFloat + 1f;"
    # This will say that TestVar is ALWAYS whatever number ExampleFloat is, but it adds one.
    
  # Int: Int (or integer) is like float, but stores whole numbers and has a higher range. They also lack the "f" that you see with a Float.
      # Example: int ExampleInt = 341351351;

  # Equals signs: Equal signs come in a few different forms, all meaning different things in the code. It's pretty straightforward, so here's all of them:
    # = and == is for setting or checking. "=" will set a var/float/int/bool as such, example: "TestBool = false". "==" will CHECK or COMPARE two things, such as "if (TestBool == false)"
    # >= or <= just means if A is less than or larger than B. Example: "if (TestFloat >= Testfloat2)", just checks if TestFloat has a higher number than TestFloat2.
    # +=, -=, *=, /=, will simply apply the mentioned math operation to the set. For example, "TestFloat += 5;" will ADD 5 to TestFloat's current number. / is divide, and * is multiply.
    # != is a false equal. It simply sees if something is NOT equal, example being: "if (Var1 != Var2)" will only run if Var1 is NOT equal to Var2

  # Loops: There's a few different types of loops, all doing different things. The two basic ones are as follows:
    # Foreach loops: foreach loops (like the name suggests) will loop over EACH thing as specified. For example, you can have a Foreach loop check every single entity with a certain component or tag.
    # While loops: While loops will continuously run until it's goal is reached. Example being "while (ExampleFloat <= 10f)". This will continously loop until ExampleFloat is greater than or equal to 10.
      
  # Exit commands: Exit commands end code when needed, either after a error or incorrect check, or other circumstances. There are three basic ones:
    # Return: Return will instantly kill a block of code, and prevent it from getting any further down the block until it is re-executed. Useful for stopping code after a known error or incorrect circumstance.
    # Break: Will "break" a loop, stopping it from continuing and canceling it. Useful if you've completed your goal with the loop and it no longer needs to exist.
    # Continue: Continue will SKIP an interation in a loop. Instead of breaking it, this instead will just cancel the current iteration and start on the next one. Useful for Foreach loops if you want to skip over certain entities.
