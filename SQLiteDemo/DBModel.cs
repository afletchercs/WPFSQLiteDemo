using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace SQLiteDemo
{
    public class DBModel : DbContext
    {
        public DbSet<Person> People { get; set; }
        //DbSet<LastName> LastNames { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "TestDB.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }


    }
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public Person(string FirstName, string LastName, string Phone = "NA", int PersonID = 0)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.PersonID = PersonID;
        }

        public string PhoneFormated()
        {
            if (this.Phone == "" || this.Phone == null) return "";
            string formatted = "(" + this.Phone.Substring(0, 3) + ")" + this.Phone.Substring(3, 3) + "-" + this.Phone.Substring(6, 4);
            return formatted;
        }
        public void WriteToLine()
        {
            Console.WriteLine("ID: {0, -7} | Name: {1,20} | Phone: {2}", this.PersonID, this.FirstName + " " + this.LastName, this.PhoneFormated());
        }
        public override string ToString()
        {
            string result = $"ID: {this.PersonID} | NAME: {this.FirstName} {this.LastName} | PHONE: {this.PhoneFormated()}";
            return result;
        }
    }

    public class People : ObservableCollection<Person>
    {       
        static string[] randomFirstNames = "Dot Kristyn Lashawna Noriko Siobhan Noble Gail Milan Nolan Philip Gloria Earlean Kurt Samuel Brinda Aretha Stephen Sarai Fredia Enriqueta Danuta Hye Marisol Wilfredo Keeley Joy Rosario Kay Deeann Juliana Tran Ayesha Monet John Bobbi Jonathon Corrine Hannah Kisha Wei Veronique Danette Albertha Camelia Connie Merideth Ernestina Lauren Providencia Edyth Neida Samira Rivka Wendie Joslyn Vincenza Minta Bennie Katherin Virgina Delila Magnolia Reita Aleen Maple Patrina Madelaine Freddie Cecily Verlene Brittni Illa Arlyne Particia Lonny Davina Wynona Ray Phillis Bernardine Lyndon Leana Gavin Thomasina Nada Shawanda Dagmar Angelia Claudia Hector Trena Garnet Rayna Deidra Bunny Josefa Malorie Tangela Tommie Melynda Booker Alene Mikki Casimira Thea Monnie Nyla Carissa Lyman Denis Rosy Eliseo Carolynn Deadra Dwana Josef Valentin Angelique Jerica Leanna Renaldo Elenora Meredith Quentin Gayle Virgen Fred Alisia Kacey Barbie Burma Ramiro Tilda Lenore Monty Dorene Sumiko Alfred Charolette Liliana Bailey Lavenia Francina Sheryl Jarrod Oneida Sommer Shalon Delmy Steven Eldon Chauncey Denese Willis Elenora Hulda Danille Delilah Noriko Erik Faviola Tammie Onita Deedra Enoch Margarite Liz Madie Rea Jasmine Odell Elise Jaclyn Susanna Clemmie Moshe Nada Liberty Ghislaine Les Rima Nakia Cecelia Josie Cleveland Ashlie Trudi Nanci Santa Cecilia Sharell Kennith Tammera Penny Wade Madelyn Carolyn Willy Lenny Jerome Perry Ivy Jessika Robbi Sheree Lucinda Reynaldo Stephen Maryanne Bethany Odilia Nicolasa Leonardo Donnell Roma Sheryl Todd Margarette Denny Loyd Albertha Amparo Harland Letitia Arnette Dione Samara Daria Noriko Dori Yasuko Regine Carley Ocie Enid Stacie Rick Fermina Domenic Pat Precious Shanita Leora Heriberto Tiny Alan Charise Michale Kym Eddie Sana Charissa Shin Erminia Emeline Callie Celeste Gus Kyung Dorathy Lecia Shelba Angila Sherell Eloise Isabell Cammy Keena Jasper Anissa Aleida Dirk Xenia Alfonzo Natalia Odessa Juanita Lean Eldora Brigette Grazyna Renetta Piedad Tom Kacy Vaughn Jung Youlanda Ivey Valentine Reggie Rosio Amina Marianela Kanesha Altagracia Latina Tammie Annalisa Vernita Brenda Walton Elvis Tonette Don Carli Orval Sparkle Tammera Leandro Tempie Donette Nathanael Reba Verlene Shavon Maisie Lala Gloria Lamont Zoila Ron Jamar Solange Jamaal Blanca Agripina Luetta Wei Mohammad Maryam Despina Jacquiline Everette Theresia Leone Melissa Waltraud Audry Donovan Jeanett Wendie Tammi Shenika Aura Efren Dia Xuan Corina Rosemary Katelin Norman Erwin Dessie Hester Ceola Santa Jolynn Duane Kerrie Melodi Tyron Lakeisha Lauran Rona Kymberly Isela Ernie Robbyn Rosy Ebonie Sunni Khadijah Hortensia Georgeann Zora Lisette Foster Nelle Hue Wan Elva Jacqualine Gillian Jessi Ilda Ezra Zandra Ona Boris Mui Christen Marhta Jeneva Ali Elinor Hyo Akiko Joshua Roger Rikki Roscoe Rachal Deeann Alisia Elinore Janett Glinda Breanna Charlette Elli Le Vernice Albert Berenice Gema Tenesha Stacee Tamar Errol Marna Tambra Luke Filomena Treva Marvella Suzy Franklin Cordelia Carlee Magda Ollie Aleida Tonita Sade Sherice Shae Casie Ka Brock Lamonica Providencia Majorie Bobby Gaylord Priscila Kina Gay Angle Sonny Celesta Beau Pamila Loraine Stacia Hung Raeann Consuelo Alene Nyla Gregoria Zachary Jina Tabitha Josephina Petra Lyman Yuki Kelley Ernesto Louetta Houston Brice Warren Cara Fabian Enriqueta Naida Nannie Pierre Jospeh Marivel Lavina Sina Bess Bryanna Tarsha Brooks Roseann Tiesha Lesli Kayleen Alycia Marcelle Laurie Estefana Coy Hellen Lurlene Janita Linda Sidney Asha Rosette Marlys Renetta Ron Leland Neida Juanita Janell Geneva Verdell Pablo Demetrice Rolando Angela German Marcela Myrta Bethann Valencia Bella Javier Rhona Nakita Coleman Enriqueta Summer Ressie Boyd Ethelyn Rashida Kirby Cammie Duane Hai Sherron Loree Kenna Cary Marcel Miriam Rosann Niki Eustolia Glenn Rosaria Lavonda Cierra Hermina Eric Alonzo Trey Hilda Lanita Demetria Lisha Tiana Marcene Jude Carola Edythe Takisha Ettie Betsy Alejandro Gracie Janean Josefine Carol Roland Tamekia Andrew Walker Thuy Imelda Milan Rosetta Alleen Carter Carlee Kimberlee Inger Alethia Awilda Syreeta Lianne Robena Renita Karleen Zita Roseann Tod Shavonda Azalee Gene Mariann Shanna Armando Johna Tonya Giuseppe Chery Marilyn Maricruz Lenard Debora Kent Karan Jamal Dodie Maddie Mozella Gino Ardith Kayla Julee Rema Beth Aron Joe Luetta Ladawn Miesha Klara Karmen Candra Antony Elouise James Marcia Loren Deann Sharron Catarina Kerrie Shakita Allena Dahlia Fiona Arthur Gilbert Dottie Ella Corinna Grant Nicholas Wilma Angeline Vivan Marion Lara Jarvis Nichol Zulma Earline Lulu Shoshana Janella Marjory Suzy Odell Tashia Grover Estela Liana Darnell Debrah Kassie Marquetta Lacresha Hermelinda Jay Normand Amalia Rhonda Edelmira Brittney Ivette Sharon Maribeth Marylee Kimberely Kaci Noriko Xochitl Delta Tommye Winona Renate Sharilyn Tasha Sherlene Ivy Dave Doug Ahmed Noel Joshua Kathrine Steffanie Minna Daphne Candida Ardelle Jadwiga Bethanie Blair Marline Tory Angelita Ardell Carry Mayme Emmy Ivette Sau Karisa Rosalba Eliana Delmer Shaquana Leonore Kenda Hassan Flavia Jaye Chiquita Tama Craig Sebastian Lora Nikita Florinda Claudine Bari Marcellus Marietta Brittany Thanh Harold Wesley Stella Mohammad Floria Fidel Shirlene Warner Delmy Keira Tamar Cindie Mana Tamera Cruz Homer Nicolasa Carolee Blaine Loyce Wm Dierdre Johnette Clorinda Phoebe Shalonda Derek Griselda Ilona Loise September Jose Bea Vanessa Yolanda Corrin Jettie Lamonica Dee Zola Anastasia Neomi Neta Nicky Etsuko Deborah Judi Cecilia Hang Olive Divina Vada Maude Delinda Pauletta Hue Caterina Ervin Noelle Berniece Camilla Gabriele Helga Ossie Senaida Kaley Tammie Antonia Conchita Edmund Luetta Rosena Jordan Jessie Vonnie Krissy June Chloe Maegan Zenaida Theola Elisha Linette Jinny Rosemary Zachary Julissa Kerstin Twanda Thelma Neville Jimmie Dominga Tyron Jarrod Monika Euna Sharita Cortez Bertram Irish Maddie Ha Jodee Lilia Ignacio Lasandra Antoinette Felisha Luanna Ahmad Theola Joel Londa Bret Hubert Corina Chanda Emory Deb Desiree Paris Nellie Pei Berta Rossana Ilona Karole Francoise Nevada Leighann Mattie Debbi Jacquie Jessica Krista Andree King Lee Many Isela Karena Karrie Lauri Jamey Moriah Domonique Jene Toby Katlyn Domenic Kathlene Genie Michelina Flavia Mathilde Karlyn Philip Cary".Split(' ');
        static string[] randomLastNames = "Polley Posner Ashley Bohn Dery Gouin Clermont Silvester Stevenson Bella Brantley Fukushima Simmerman Sarro Brzezinski Hipp Ferris Padgett Lesesne Didonna Connors Pickle Castor Nevarez Bonacci Homan Rashid Foskey Reeser Hervey Vicario Reach Portugal Hebert Inskeep Dull Dysart Gallien Weimer Ishii Chalfant Zeno Gober Pirtle Avitia Brott Collar Prejean Payson Dingler Lower Albanese Strouth Swarts Killinger Ott Smythe Dyches Cuadrado Brasher Graziani Kitzman Tregre Natera Propst Ochsner Penrod Slankard Bieber Olinger Jenkin Carroll Pechacek Gaertner Hack Dillingham Baylor Steen Larosa Greenleaf Metz Kidder Marquis Steier Wadley Mccallister Beal Bulmer Smyre Frandsen Marzano Heaston Guidroz Washinton Ostroff Mallow Cotter Thiel Wheelwright Oshiro Mccrystal Mouser Newland Ishida Hazel Zufelt Kimberling Woodrow Hawkins Meyerhoff Pressly Tarleton Branton Skelley Dickman Sluss Smolka Manfre Steinke People Deason Hover Harvard Canup Abbey Klingenberg Risko Padua Reiman Jamar Hixon Augustine Thayer Hillwig Lovins Waters Hartzog Lamorte Pickert Streit Jong Huckabee Beaird Headlee Hetzel Mcphearson Wooding Lansberry Traub Liggins Sherry Lee Salvas Lintner Blythe Knauss Hodgkinson Earwood Hoffmann Lessig Marcotte Hubert Haag Aquino Mckinnie Alicea Lisowski Ott Rohloff Burda Level Valcourt Mcfalls Kluck Devos Linkous Blaisdell Ringgold Zick Cartwright Dilbeck Sapienza Blick Pressley Eakins Cecere Weyer Kang Shotwell Strahan Fischbach Sun Fraher Marquess Maudlin Nedd Phipps Mcelligott Bayer Belding Gluck Mattson Schimpf Lovitt Hitchings Cahill Alcock Lohman Mitzel Bassi Depriest Liefer Mcmillen Hartung Nealy Hertel Ota Hollinger Buie Osman Sheely Como Brenton Seaton Coster Lafontaine Wormley Quintero Walla Sluss Becton Overcash Snodgrass Hemingway Satterlee Roda Weideman Pinegar Smiddy Selvage Pelton Ashbrook Vashon Willoughby Wolfe Vencill Gano Collinson Copper Holtzen Gerstein Melchor Revel Sulser Dapolito Carreras Kellett Kilbourn Godinez Winans Ricca Durant Vanwagenen Gaeta Vazquez Hagenbuch Ruf Caouette Connell Valenzuela Bouchard Penfield Mascarenas Milano Silveira Gangemi Charney Hurla Lemley Thatcher Harward Zendejas Faircloth Mey Blatter Huse Griffieth Rosin Tubman Langlois Meritt Fennelly Piraino Rollo Nida Amis Altman Leet Wingate Calkins Ester Raver Cygan Leverett Ray Giancola Elsberry Hopwood Sluss Picha Kinser Alcott Lukes Sick Blackshear Kempker Popham Clower Philippe Rodrigues Stearman Barbosa Elkington Wirt Novak Guillaume Rita Mchale Durante Austell Varela Tison Maybee Barsky Szymanski Guse Millward Castilla Woodman Sweatt Huggins Ormiston Mehr Wise Starkey Ridlon Tippie Mccue Wigginton Ingham Huhn Makin Tice Maguire Childress Blann Doering Lansford Gleason Warwick Difiore Esses Buff Kennard Say Redwood May Couture Mcgary Kearney Seidman Hosch Seamans Rahaim Fortune Costello Lively Cunningham Vara Holguin Estey Mclendon Record Eusebio Mcivor Nutting Krasner Craighead Ruppel Huber Feiler Temple Venema Shadrick Holyfield Friedel Lamprecht Baumgarten Mcraney Sitsler Drew Raffaele Christo Greenhaw Stipe Lawing Polo Clerk Cheever Dansby Hillyard Schauwecker Lefevers Scheffler Siewert Oquin Oliver Eisenmann Osbourn Buono Gass Prigge Draves Waldroup Police Cather Gauna Seegmiller Tindle Moos Cleaves Muth Galarza Gutter Mudd Franko Beller Harriston Huizenga Mcleod Corrales Agtarap Mckillop Ingrassia Folger Fenske Desmond Hohn Sedberry Osby Gonce Hauff Greenman Minjares Mattews Solan Negrete Chen Seybold Cun Roussell Days Sirmons Bermudez Ringgold Carollo Barcenas Rollings Piccard Bortle Kear Spears Lounsbury Gonzalas Cumbee Mcnair Compton Brenton Cressman Stacker Armstong Hori Mcquaig Fedele Alameda Emig Flohr Rutkowski Edlund Chipps Borman Long Rotz Pinegar Lang Hruby Feather Rabe Gallman Foshee Skelley Wronski Ellett Mcclung Gowdy Matsui Dalal Snapp Caudell Linebaugh Reily Hartwick Gerard Moorhead Paugh Levison Ullrich Foulds Huse Riffe Tseng Despain Lough Marcy Rivenbark Chatterton Below Gatson Goings Corbo Baptiste Halloway Kubacki Slinkard Orange Duckett Emond Lolley Monroy Horstmann Flake Pompa Rolfes Schenck Hayman Bastin Stutler Pates Ziemer Aubrey Arriola Ciancio Carlson Minogue Sensabaugh Bridge Kromer Kraker Muldowney Paulin Clifford Spagnola Deasy Cebula Simmons Gupta Beckerman Timothy Durrah Fowles Scianna Campfield Clayborn Litz Mayville Hassett Belford Mccune Pleas Gaskamp Eilerman Goupil Gotto Laury Northrop Parker Youngman Tienda Kato Humbertson Fortin Mcauliffe Leth Mcewan Chew Schwarz Mulherin Serna Sheldon Germano Tallant Lunsford Mcclary Woodside Gholson Holm Wentzell Cambron Tardiff Lever Michell Kunzman Sharlow Tong Turnage Flippen Darsey Liddle Augustin Holle Sheroan Meisel Hutto Wellington Abramowitz Salido Cappello Mckell Scarlett Shearer Barbe Zieman Salvetti Loveland Mckissick Mahone Rozman Filler Vickrey Farr Bermudez Quijas Switzer Elton Bown Magar Eckert Burtner Bartley Hildebrant Sensabaugh Dore Derouin Weikel Bellows Stallworth Mcdaniels Roland Kuck Trejo Radley Dukes Patti Ashurst Hakim Marlin Consolini Mcauliffe Greenman Wendel Moronta Dahl Fontana Ihle Mcnab Maisonet Maravilla Wall Gagnon Burgess Norfleet Farone Terranova Olivar Corp Evangelista Marston Savant Ange Ruffino Weems Quellette Paetzold Terrazas Lovick Harris Severino Fleishman Coursey Spielman Such Rayborn Havener Gormley Charrier Kina Trudell Randall Shimkus Mcglothin Moon Garris Furr Wendler Alsop Norden Smathers Horsley Kendra Lampkin Blazer Frenz Whitelow Gonzalez Roney Ballou Macklin Malagon Mcdonell Mccaulley Ogletree Sensabaugh Reichert Fiscus Witcher Vantassell Ager Sabin Butterworth Sites Peay Heidenreich Coolbaugh Hood Trott Tull Dutcher Cowherd Caughey Say Palmquist Lauritsen Chirico Sova Croney Yarberry Jeske Borrero Evelyn Rodiguez Schoonover Mower Novy Greiner Vorpahl Hampton Polley Touchette Bozeman Addie Kasel Ewald Victorino Gayer Rhymer Grams Coover Lynn Machin Chambliss Rumery Montoro Burpee George Kingsberry Schiavone Girardi Guidroz Achenbach Bergey Izzard Lenzi Hedgepeth Stimson Partin Swearngin Hendley Judy Addison Simmons Benes Eger Jennette Mcbrayer Laduke Chase Bjelland Determan Tapp Giraud Briski Snelling Hertz Kratky Klapper Shultz Venuti Gracey Searls Toon Kifer Eichenlaub Keeney Henrickson Hilden Ashman Purves Dix Pichette Siemers Sam Warburton Hegarty Espana Kuehn Zamarripa Polzin Tankersley Sexton Filer Reed Weakley Hower Stokes Sikes Mcneece Silverstein Loftus Noble Fogg Knight Jay Coates Bartolome Hennessey Munez Baxendale Gary Gilbride Sobota Terrell Hair Borders Vallee Hagstrom Krom Carlisle Hilton Miler Hallman Kepley Franson Mishoe Exner Fiorentino Nipp Irizarry Mccown Mundo Withrow Steffensmeier Bartel Scoles Siegfried Plum Euell Gaudreau Kilgo Koeppel Schulte Dunworth Thompkins Brierly Mars Hanselman Friedrichs Remo Pesce Rockwell Luckie".Split(' ');
              
        public int NumberOfPeople { get { return this.Count; } }
        public Person AddPerson(string firstName, string lastName)
        {
            string phone = RandomPhoneNumber();
            Person currentPerson = new Person(firstName, lastName, phone);
            this.Add(currentPerson);
            return currentPerson;

        }
        public bool RemovePerson(Person person)
        {
            if (this.Contains(person))
            {
                this.Remove(person);
                return true;
            }
            return false;
        }
        public void RemovePeople(List<Person> people)
        {
            foreach (Person p in people)
            {
                RemovePerson(p);
            }
        }
        public List<Person> AddRandomPeople(int number)
        {
            Random rand = new Random();
            List<Person> tempPeople = new List<Person>();

            for (int i = 0; i < number; i++)
            {
                int first = rand.Next(randomFirstNames.Length);
                int last = rand.Next(randomLastNames.Length);
                string phone = RandomPhoneNumber();
                Person currentPerson = new Person(randomFirstNames[first], randomLastNames[last], phone);
                tempPeople.Add(currentPerson);
                this.Add(currentPerson);
            }
            return tempPeople;
        }
        public Person AddRandomPerson()
        {
            Random rand = new Random();
            int first = rand.Next(randomFirstNames.Length);
            int last = rand.Next(randomLastNames.Length);
            string phone = RandomPhoneNumber();
            Person currentPerson = new Person(randomFirstNames[first], randomLastNames[last], phone);
            this.Add(currentPerson);
            return currentPerson;
        }
        private string RandomPhoneNumber()
        {
            Random rand = new Random();
            string areacode = rand.Next(111, 999).ToString();
            string result = rand.Next(1111111, 9999999).ToString();
            return areacode + result;
        }
    }
}


