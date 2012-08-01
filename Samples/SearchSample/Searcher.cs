using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Unbiasiedsearch
{
    class Searcher
    {
        bool notthereyet = true;
        List<Node> myNodes = new List<Node>();
        List<Node> placesIHaveBeen = new List<Node>();
        List<Node> placesThatFailed = new List<Node>();
        int count = 0;
        Node placetobe;
        Node placetoStart;
        Texture2D tex;
        Texture2D nodeTex;

        Node neamt = new Node("Neamt", new Vector2(494, 78));
        Node iasi = new Node("Iasi", new Vector2(593, 115));
        Node vaslui = new Node("Vaslui", new Vector2(644, 185));
        Node urziceni = new Node("Urziceni", new Vector2(564, 296));
        Node hirsova = new Node("Hirsova", new Vector2(694, 299));
        Node eforie = new Node("Eforie", new Vector2(724, 380));
        Node bucharest = new Node("Bucharest", new Vector2(490, 325));
        Node giurgiu = new Node("Girugiu", new Vector2(432, 432));
        Node fagaras = new Node("Fagaras", new Vector2(375, 175));
        Node sibiu = new Node("Sibiu", new Vector2(250, 157));
        Node pitesti = new Node("Pitesti", new Vector2(370, 293));
        Node rimnicu = new Node("Rimnicu", new Vector2(279, 226));
        Node craiova = new Node("Craiova", new Vector2(310, 409));
        Node dobreta = new Node("Dobreta", new Vector2(200, 389));
        Node mehadia = new Node("Mehadia", new Vector2(211, 349));
        Node lugoj = new Node("Lugoj", new Vector2(211, 287));
        Node timisoara = new Node("Timisoara", new Vector2(109, 247));
        Node arad = new Node("Arad", new Vector2(109, 147));
        Node zerind = new Node("Zerind", new Vector2(128, 76));
        Node oradea = new Node("Oradea", new Vector2(158, 24));
        public Searcher()
        {

            oradea.addConnection(ref zerind);
            oradea.addConnection(ref sibiu);
            zerind.addConnection(ref arad);
            arad.addConnection(ref sibiu);
            arad.addConnection(ref timisoara);
            timisoara.addConnection(ref lugoj);
            lugoj.addConnection(ref mehadia);
            mehadia.addConnection(ref dobreta);
            dobreta.addConnection(ref craiova);
            craiova.addConnection(ref rimnicu);
            sibiu.addConnection(ref rimnicu);
            sibiu.addConnection(ref fagaras);
            rimnicu.addConnection(ref pitesti);
            pitesti.addConnection(ref craiova);
            pitesti.addConnection(ref bucharest);
            fagaras.addConnection(ref bucharest);
            bucharest.addConnection(ref giurgiu);
            bucharest.addConnection(ref urziceni);
            urziceni.addConnection(ref hirsova);
            hirsova.addConnection(ref eforie);
            urziceni.addConnection(ref vaslui);
            vaslui.addConnection(ref iasi);
            iasi.addConnection(ref neamt);


            myNodes.Add(neamt);
            myNodes.Add(iasi);
            myNodes.Add(vaslui);
            myNodes.Add(urziceni);
            myNodes.Add(hirsova);
            myNodes.Add(eforie);
            myNodes.Add(bucharest);
            myNodes.Add(giurgiu);
            myNodes.Add(fagaras);
            myNodes.Add(pitesti);
            myNodes.Add(rimnicu);
            myNodes.Add(craiova);
            myNodes.Add(sibiu);
            myNodes.Add(dobreta);
            myNodes.Add(mehadia);
            myNodes.Add(lugoj);
            myNodes.Add(timisoara);
            myNodes.Add(arad);
            myNodes.Add(oradea);
            myNodes.Add(zerind);

            placetobe = giurgiu;
            placetoStart = eforie;

        }

        public void initialize(ContentManager inContent)
        {
            tex = inContent.Load<Texture2D>("line");
            nodeTex = inContent.Load<Texture2D>("ball");
        }

        public void getPath()
        {
            placesThatFailed.Clear();
            placesIHaveBeen.Clear();
            notthereyet = true;
            placesIHaveBeen.Add(placetoStart);
            count = 0;
            while (notthereyet == true)
            {
                shortestConnection(placetoStart);


            }

            printPath();

        }



        public void printPath()
        {
          
            foreach (Node anode in placesIHaveBeen)
            {
                Console.WriteLine("Go to: " + anode.name);
            }
            placesIHaveBeen.Add(placetobe);
            Console.WriteLine("Arrive at: " + placetobe.name);

        }


        private void weThereyet(Node Anode)
        {

            foreach (Node bNode in Anode.theConnections)
            {
                if (bNode.Equals(Anode))
                {
                    continue;
                }
                if (bNode.Equals(placetobe) == true)
                {
                    notthereyet = false;
                    clean();
                    break;
                }

                if (placesThatFailed.Contains(bNode) == true)
                {
                    placesThatFailed.Add(bNode);
                    continue;
                }
                if (toReturn(bNode) == true)
                {
                    count--;
                    placesThatFailed.Add(bNode);
                    weThereyet(Anode);


                }


                if (placesIHaveBeen.Contains(bNode) == true)
                {
                    //placesThatFailed.Add(bNode);
                    continue;
                }



                if (notthereyet == false)
                {
                    break;
                }

                if (Anode.Equals(bNode))
                {
                    //count--;
                    //placesIHaveBeen.RemoveAt(count);
                    //weThereyet(placesIHaveBeen.Last());
                    continue;
                }


                else
                {
                    count++;
                    if (Anode == placetobe)
                    {
                        break;
                    }
                    //weThereyet(shortestConnection(Anode));

                }
            }
            if (notthereyet == true)
            {
                placesThatFailed.Add(Anode);
            }


        }

        private void clean()
        {
            foreach (Node anode in placesThatFailed)
            {
                if (placesIHaveBeen.Contains(anode) == true)
                {
                    placesIHaveBeen.Remove(anode);
                }
            }
        }

        private bool checkIfContainsAll(List<Node> aList, List<Node> bList)
        {
            bool contains = false;
            if (aList.Count == 0)
            {
                return contains = false;
            }
            foreach (Node cnode in bList)
            {
                if (aList.Contains(cnode) == false)
                {
                    contains = false;
                    break;
                }
                contains = true;
            }
            return contains;
        }


        private bool toReturn(Node bNode)
        {
            bool shouldReturn = false;

            if (bNode.theConnections.Count == 0)
            {
                shouldReturn = true;
            }
            if (checkIfContainsAll(bNode.theConnections, placesThatFailed) == true)
            {
                shouldReturn = true;
            }



            return shouldReturn;
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            foreach (Node aNode in myNodes)
            {
                theSpriteBatch.Begin();
                theSpriteBatch.Draw(nodeTex, new Rectangle((int)aNode.Position.X, (int)aNode.Position.Y, 26, 26), Color.White);
                theSpriteBatch.End();
            }

            if (notthereyet == false)
            {
                theSpriteBatch.Begin();
                for (int index = 0; index < placesIHaveBeen.Count - 1; index++)
                {
                    theSpriteBatch.Draw(tex, new Rectangle((int)placesIHaveBeen[index].Position.X,
                        (int)placesIHaveBeen[index].Position.Y,
                        ((int)placesIHaveBeen[index + 1].Position.X - (int)placesIHaveBeen[index].Position.X),
                        10), null, Color.White,
                        (float)Math.Atan2((double)placesIHaveBeen[index + 1].Position.Y - (double)placesIHaveBeen[index].Position.Y, (double)placesIHaveBeen[index + 1].Position.X - (double)placesIHaveBeen[index].Position.X), Vector2.Zero, SpriteEffects.None, 0);


                }
                theSpriteBatch.End();
            }

        }

        public void Update()
        {
            foreach (Node aNode in myNodes)
            {
                aNode.Update();
            }
           
        }

        public void setStart(Vector2 loc)
        {

            foreach (Node aNode in myNodes)
            {
                if (aNode.Rectangle.Contains((int)loc.X, (int) loc.Y) == true)
                {
                    placetoStart = aNode;
                }
            }
        }

        public void setEnd(Vector2 loc)
        {

            foreach (Node aNode in myNodes)
            {
                if (aNode.Rectangle.Contains((int)loc.X, (int)loc.Y) == true)
                {
                    placetobe = aNode;
                }
            }
        }

        public void shortestConnection(Node aNode)
        {
            
            Node shortest = aNode.theConnections[0];
            foreach (Node bNode in aNode.theConnections)
            {
                if (bNode.theConnections.Count == 1)
                {
                    //continue;
                }
               
                if (aNode.Distance(bNode.Position) + bNode.Distance(placetobe.Position)  < aNode.Distance(shortest.Position) + shortest.Distance(placetobe.Position))
                {
                    shortest = bNode;
                }
                if (bNode.Equals(placetobe) || aNode.Equals(placetobe))
                {
                    shortest = bNode;
                    notthereyet = false;
                    break;
                }
            }
            
            placesIHaveBeen.Add(shortest);
            Console.WriteLine("Connecting To: " + shortest.name);
            Console.WriteLine(aNode.Distance(shortest.Position).ToString());
            if (notthereyet == true)
            {
                shortestConnection(shortest);
            }
        }


    }
}
