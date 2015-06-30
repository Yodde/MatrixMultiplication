using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplication {
    class Program {
        Random rand;
        int a = 20, b = 15, c = 33;
        const int maxNumber = 100;
        int[,] matrix1, matrix2, matrixResult;
        public Program() {
            rand = new Random();
            matrix1 = new int[a, b];
            matrix2 = new int[b, c];
            matrixResult = new int[a, c];
            for(int i = 0; i < a; i++)
                for(int j = 0; j < b; j++)
                    matrix1[i, j] = rand.Next(maxNumber);
            for(int i = 0; i < b; i++)
                for(int j = 0; j < c; j++)
                    matrix2[i, j] = rand.Next(maxNumber);

        }
        static void Main(string[] args) {
            Program p = new Program();
            p.multiplicateTasks();
            for(int i = 0; i < p.a; i++) {
                for(int j = 0; j < p.c; j++)
                    Console.Write(p.matrixResult[i, j] + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        void multiplicate() {
            for(int i = 0; i < a; i++)
                for(int j = 0; j < c; j++)
                    matrixResult[i, j] = 0;

            for(int i = 0; i < a; i++) {
                for(int j = 0; j < c; j++) {
                    for(int k = 0; k < b; k++) {
                        matrixResult[i, j] += matrix1[i, k] * matrix2[k, j];
                    }

                }
            }
        }
        void multiplicateTasks() {
            List<Task> tasks = new List<Task>();
            for(int i = 0; i < a; i++)
                for(int j = 0; j < c; j++)
                    matrixResult[i, j] = 0;

            for(int i = 0; i < a; i++) {
                for(int j = 0; j < c; j++) {
                    int tempi = i, tempj = j;
                    tasks.Add(Task.Run(() => {
                        for(int k = 0; k < b; k++)
                            // lock(this)
                            matrixResult[tempi, tempj] += matrix1[tempi, k] * matrix2[k, tempj];

                    }));
                }
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
