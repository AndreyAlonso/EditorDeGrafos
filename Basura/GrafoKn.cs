  private void numericUpDown1_ValueChanged(object sender, EventArgs e) // Numeric del Grafo Kn
  {
    grafo.Clear();
    grafo.Aristas.Clear();
    this.Form1_Paint(this, null);

    int a;
    int b;
    float centrox, centroy, distancia,angulo, angulo2;
    centrox = 400;
    centroy = 400;
    distancia = 200;
    angulo2 = (float)( 360/numericUpDown1.Value);

    float posx, posy;




    char nomb = 'A';
    Point pos = new Point(200, 200);
    angulo = 0;
    for(a = 0; a < (int)(numericUpDown1.Value); a++)
    {
        if(a == 0)
        {
            posx = (float)(centrox + (distancia * (int)Math.Cos((90* Math.PI)/180.0 )));
            posy = (float)(centroy - (distancia * (int)Math.Sin((90 * Math.PI) / 180.0)));
            pos.X = (int)posx;
            pos.Y = (int)posy;
            angulo = 90;

        }
        else
        {

            angulo = angulo + angulo2;
            posx = (int)(centrox + distancia * Math.Cos((angulo * Math.PI)/180.0));
            posy = (int)(centroy - distancia * Math.Sin((angulo * Math.PI) / 180.0));
            pos.X = (int)posx;
            pos.Y = (int)posy;
        }


        grafo.Add(new NodoP(pos, nomb));
        if(a == 1)
        {
            grafo.AgregaArista(new Arista(0, grafo[a], grafo[a-1], nomb.ToString()));
        }
        if(a > 1)
        {
            for(b = 0; b < a; b++)
            grafo.AgregaArista(new Arista(0, grafo[a], grafo[b], nomb.ToString()));
        }


        grafo.pinta(g, Color.Black, tam, colari, ancho, tamLetra);
        pos.X += 100;
        nomb++;
    }



}