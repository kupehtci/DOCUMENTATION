#JAVA #JavaCC 
#### JAVA CC


This is a basic JavaCC parser that let you define tokens that get readed from the input


```Java
options
{
  JDK_VERSION = "1.5";
  STATIC = true;
  DEBUG_TOKEN_MANAGER = false;
  GRAMMAR_ENCODING = "UTF-8"; // (default file.encoding)
  LOOKAHEAD = 1;
}

PARSER_BEGIN(KML_lexer)
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;

public class KML_lexer{} //De momento no construimos el parser, solo nos interesa el Scanner/Lexer

PARSER_END(KML_lexer)

TOKEN_MGR_DECLS : {

//Codigo necesario para extraer todos los tokens del fichero
public static void main(String args [])  
{
    FileInputStream myfile = null;
    KML_lexer lexer=null;
    int option=0;
    try {
      InputStreamReader isr = new InputStreamReader(System.in);
      BufferedReader bf = new BufferedReader(isr);
      System.out.println("Configuracion de codigo fuente a analizar");
      System.out.println("\t[1] Lectura por teclado");
      System.out.println("\t[2] Lectura desde fichero");
      
      option = Integer.parseInt(bf.readLine());
      if (option == 1)
      {
        System.out.println("Configurada lectura por teclado. Introduce el codigo fuente");
        lexer = new KML_lexer( System.in ) ;
      }
      else if (option == 2)
      {
        System.out.println("Introduce el nombre del fichero fuente");
        myfile = new FileInputStream(bf.readLine());
        lexer = new KML_lexer ( myfile ) ;
      }
    } catch (Exception e1) {
      // TODO Auto-generated catch block
      e1.printStackTrace();
    }

    while (true)
    {
      try
      {
        Token myToken=lexer.getNextToken();
        if (myToken.kind==lexer.EOF)
        {
          System.out.println("Leido final del fichero");
          System.exit(0);
        }
        System.out.println("Leido lexema: " + myToken.image + "\t-->Token:  " + lexer.tokenImage[myToken.kind]);
      } catch (TokenMgrError e) {
        System.out.println(e.getMessage());
        if (option == 1) lexer.ReInit(System.in);
        else if (option==2) lexer.getNextToken();
      }
    }
  }
}

SKIP:
{
	  < " " >
	| < "\r" >
	| < "\t" >
	| < "\n" >
}

TOKEN:
{
	//Here define the accepted tokens
}
```


You will need to complete the `TOKEN:{}` section with the tokens definition[[JavaCC Token definition]] in Regular Expressions format [[Regular Expressions]]. 