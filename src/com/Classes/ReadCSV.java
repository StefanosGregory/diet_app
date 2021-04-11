package com.Classes;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class ReadCSV {

    // Constructor
    public ReadCSV(){
        try {
            Scanner scanner = new Scanner(new File("Data/foods_and_chars.csv")).useDelimiter(",");
            while (scanner.hasNext()){
                System.out.print(scanner.next());
            }
            scanner.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}
