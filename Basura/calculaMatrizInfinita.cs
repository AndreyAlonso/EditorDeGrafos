public void calculaMatriz(Grafo grafo)
        {
         /*   
            int a = 0;
            int c = 0;
            int i = 0;
            int j = 1;

            foreach (NodoP aux1 in grafo)
            {




                MessageBox.Show("[" + i +"],["+ (j-1) + "]");
                c = 0;
                foreach (Arista nr in aux1.aristas)
                {
                        
                    foreach (NodoP compara in grafo)
                    {
                        if (nr.destino == compara)
                        {
                            a = 1;
                            break;
                        }
                        else
                        {
                            a = 0;
                        }
                            
                        c = c + (a * a);
                    }
                }
                dataGridView1.Rows[i].Cells[j].Value = c;
                j++;
                c = 0;
                if (j == grafo.Count+1)
                {
                    j = 1;
                    i++;
                    
                }
                    
                
              
            }


            */
            
            int i, j;
            int num = (int)numericUpDown1.Value;
            if( num < 1000)
            {
                num--;
                i = 0;
                j = 1;
                Arista band;
                foreach (NodoP np in grafo)
                {
                    i = 0;
                    foreach (NodoP n in grafo)
                    {

                        band = np.aristas.Find(x => x.destino.nombre.Equals(n.nombre));
                        if (band == null) // Si no hay relacion
                        {
                            if ((int)numericUpDown1.Value % 2 == 0) // Si es par  entonces
                            {
                                dataGridView1.Rows[i].Cells[j].Value = Math.Pow(2, num);

                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[j].Value = 0;
                            }

                            i++;
                        }
                        else // SI hay relacion
                        {
                            if ((int)numericUpDown1.Value % 2 == 0)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = 0;
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[j].Value = Math.Pow(2, num);
                            }

                            i++;
                        }




                    }
                    j++;
                }
            }
            
            
            
        }