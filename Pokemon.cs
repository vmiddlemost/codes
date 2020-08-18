using System;
using System.Collections.Generic;

public class moves {
    public string name { get; set; }
    public string type { get; set; }
    public string category { get; set; }
    public int power { get; set; }
    public int accuracy { get; set; }
    public int PP { get; set; }
    public double crit { get; set; }
    public int maxPP { get; set; }
    public bool flinch { get; set; }
    public bool freeze { get; set; }

}
public class pokemon {
    public string name { get; set; }
    public string type1 { get; set; }
    public string type2 { get; set; }
    public int maxHealth { get; set; }
    public int health { get; set; }
    public int attack { get; set; }
    public int defense { get; set; }
    public int sp_attack { get; set; }
    public int sp_defense { get; set; }
    public int speed { get; set; }
    public int move1 { get; set; }
    public int move2 { get; set; }
    public int move3 { get; set; }
    public int move4 { get; set; }
    public string status { get; set; }
    public bool confused { get; set; }
    public bool roosting { get; set; }
    public bool flinching { get; set; }

}
class Program {
    public class global {
        public static int turn = 0;
        public static Random rand = new Random();
        public static List<moves> moves = set_up_moves();
        public static List<pokemon> pokemon = set_up_pokemon();
        public static int red_defense_stage = 0;
        public static int blue_defense_stage = 0;
    }
    public static List<moves> set_up_moves() {
        List<moves> moves = new List<moves>();

        // Dragon Pulse == 0
        moves.Add(new moves {
            accuracy = 100,
            category = "Special",
            name = "Dragon Pulse",
            power = 85,
            PP = 10,
            maxPP = 10,
            type = "Dragon",
            crit = 0.04167
        });
        // Thunder Wave == 1 (paralysing move)
        moves.Add(new moves {
            accuracy = 90,
            category = "Status",
            name = "Thunder Wave",
            power = 0,
            PP = 20,
            maxPP = 20,
            type = "Electric",
            crit = 0
        });
        // Ice Punch == 2 (has a 10% chance to freeze)
        moves.Add(new moves {
            accuracy = 100,
            category = "Physical",
            name = "Ice Punch",
            power = 75,
            PP = 15,
            maxPP = 15,
            type = "Ice",
            freeze = true,
            crit = 0.04167
        });
        // Roost == 3 (heals half of max HP but loses flying type temporarily)
        moves.Add(new moves {
            accuracy = 100,
            category = "Status",
            name = "Roost",
            power = 0,
            PP = 10,
            maxPP = 10,
            type = "Flying",
            crit = 0
        });
        // Earthquake == 4
        moves.Add(new moves {
            accuracy = 100,
            category = "Physical",
            name = "Earthquake",
            power = 100,
            PP = 10,
            maxPP = 10,
            type = "Ground",
            crit = 0.04167
        });
        // Screech == 5 (greatly lowers defense of target)
        moves.Add(new moves {
            accuracy = 85,
            category = "Status",
            name = "Screech",
            power = 0,
            PP = 40,
            maxPP = 40,
            type = "Normal",
            crit = 0
        });
        // Dark Pulse == 6 (20% chance to flinch if first to attack)
        moves.Add(new moves {
            accuracy = 100,
            category = "Special",
            name = "Dark Pulse",
            power = 80,
            PP = 15,
            maxPP = 15,
            type = "Dark",
            flinch = true,
            crit = 0.04167
        });
        // Iron Defense == 7 (greatly increases defense)
        moves.Add(new moves {
            accuracy = 100,
            category = "Status",
            name = "Iron Defense",
            power = 0,
            PP = 15,
            maxPP = 15,
            type = "Steel",
            crit = 0
        });

        return moves;
    }

    public static List<pokemon> set_up_pokemon() {
        List<pokemon> pokemon = new List<pokemon>();

        // Dragonite == 0
        pokemon.Add(new pokemon {
            name = "Dragonite",
            type1 = "Dragon",
            type2 = "Flying",
            health = 386,
            maxHealth = 386,
            attack = 403,
            defense = 317,
            sp_attack = 328,
            sp_defense = 328,
            speed = 284,
            move1 = 0,
            move2 = 1,
            move3 = 2,
            move4 = 3,
            confused = false,
            roosting = false,
            flinching = false,
            status = "Normal"
        });
        // Tyranitar == 1
        pokemon.Add(new pokemon {
            name = "Tyranitar",
            type1 = "Rock",
            type2 = "Dark",
            health = 404,
            maxHealth = 404,
            attack = 403,
            defense = 350,
            sp_attack = 317,
            sp_defense = 328,
            speed = 243,
            move1 = 4,
            move2 = 5,
            move3 = 6,
            move4 = 7,
            confused = false,
            status = "Normal"
        });

        return pokemon;
        
    }

    public static double effectiveness(int x, string type) {
        // dark, ground, ice & dragon
        double modifer = 1;
        int y = 0;
        if (x == 0)
            y = 1;
        
        switch(type) {
            case "Dark":
                if (global.pokemon[y].type1 == "Ghost" || global.pokemon[y].type1 == "Psychic") {
                    modifer *= 2;
                } else if (global.pokemon[y].type1 == "Fighting" || global.pokemon[y].type1 == "Dark" || global.pokemon[y].type1 == "Fairy") {
                    modifer *= 0.5;
                }
                if (global.pokemon[y].type2 == "Ghost" || global.pokemon[y].type2 == "Psychic") {
                    modifer *= 2;
                } else if (global.pokemon[y].type2 == "Fighting" || global.pokemon[y].type2 == "Dark" || global.pokemon[y].type2 == "Fairy") {
                    modifer *= 0.5;
                } break;
            case "Ground":
                if (global.pokemon[y].type1 == "Poison" || global.pokemon[y].type1 == "Rock" || global.pokemon[y].type1 == "Steel" || global.pokemon[y].type1 == "Fire" || global.pokemon[y].type1 == "Electric") {
                    modifer *= 2;
                } else if (global.pokemon[y].type1 == "Bug" || global.pokemon[y].type1 == "Grass") {
                    modifer *= 0.5;
                } else if (global.pokemon[y].type1 == "Flying") {
                    modifer *= 0;
                }
                if (global.pokemon[y].type2 == "Poison" || global.pokemon[y].type2 == "Rock" || global.pokemon[y].type2 == "Steel" || global.pokemon[y].type2 == "Fire" || global.pokemon[y].type2 == "Electric") {
                    modifer *= 2;
                } else if (global.pokemon[y].type2 == "Bug" || global.pokemon[y].type2 == "Grass") {
                    modifer *= 0.5;
                } else if (global.pokemon[y].type2 == "Flying") {
                    modifer *= 0;
                } break;
            case "Ice":
                if (global.pokemon[y].type1 == "Flying" || global.pokemon[y].type1 == "Grass" || global.pokemon[y].type1 == "Ground" || global.pokemon[y].type1 == "Dragon") {
                    modifer *= 2;
                } else if (global.pokemon[y].type1 == "Steel" || global.pokemon[y].type1 == "Ice" || global.pokemon[y].type1 == "Fire" || global.pokemon[y].type1 == "Water") {
                    modifer *= 0.5;
                }
                if (global.pokemon[y].type2 == "Flying" || global.pokemon[y].type2 == "Grass" || global.pokemon[y].type2 == "Ground" || global.pokemon[y].type2 == "Dragon") {
                    modifer *= 2;
                } else if (global.pokemon[y].type2 == "Steel" || global.pokemon[y].type2 == "Ice" || global.pokemon[y].type2 == "Fire" || global.pokemon[y].type2 == "Water") {
                    modifer *= 0.5;
                } break;
            case "Dragon":
                if (global.pokemon[y].type1 == "Dragon") {
                    modifer *= 2;
                } else if (global.pokemon[y].type1 == "Steel" || global.pokemon[y].type1 == "Fairy") {
                    modifer *= 0.5;
                }
                if (global.pokemon[y].type2 == "Dragon") {
                    modifer *= 2;
                } else if (global.pokemon[y].type2 == "Steel" || global.pokemon[y].type2 == "Fairy") {
                    modifer *= 0.5;
                } break;  
        }
        return modifer;
    }

    public static bool hasHit(int accuracy) {
        if (global.rand.Next(1, 101) > accuracy) {
            Console.WriteLine("The attack missed!");
            return false;
        } else {
            return true;
        }
    }

    public static int damage(int x, int power, string type, string category, double crit, int accuracy, bool flinch, bool freeze) {

        double dmg = 0;
        int y = 0;
        if (x == 0)
            y = 1;

        if (!hasHit(accuracy))
            return 0;

        switch(category) {
            case "Special":
                dmg = ((42 * (power) * (((float)global.pokemon[x].sp_attack) / ((float)global.pokemon[y].sp_defense))) / 50) + 2;
                break;
            case "Physical":
                dmg = ((42 * (power) * (((float)global.pokemon[x].attack) / ((float)global.pokemon[y].defense))) / 50) + 2;
                break;
        }

        if (flinch && global.rand.Next(1,6) == 5)
            global.pokemon[y].flinching = true;
        

        if (freeze && global.rand.Next(1,11) == 10 && global.pokemon[y].status == "Normal") {
            Console.WriteLine($"{global.pokemon[y].name} has been Frozen!");
            global.pokemon[y].status = "Frozen";
        }

        // damage modifiers
        // random damage modifier

        dmg *= global.rand.Next(85,101);
        dmg /= 100;

        // effectiveness modifer

        if (effectiveness(x, type) == 0) {
            Console.WriteLine("It has no effect...");
        } else if (effectiveness(x, type) < 1) {
            Console.WriteLine("It wasn't very effective...");
        } else if (effectiveness(x, type) > 1) {
            Console.WriteLine("It's super effective!");
        }
        dmg *= effectiveness(x, type);

        // crit chance modifer

        int critChance = global.rand.Next(1, 100001);
        if (critChance <= crit * 100000) {
            dmg *= 2;
            Console.WriteLine("It's a critical hit!");
        }

        // same type attack bonus

        if (type == global.pokemon[x].type1 || type == global.pokemon[x].type2)
            dmg *= 1.5;

        return(int)dmg;
        
    }

    /*public static bool confusion(int x) {
        if (global.pokemon[x].confused) {

        }
    }*/

    public static bool statusEffects(int x, string status) {
        switch (status) {
            case "Paralyzed":
                if (global.rand.Next(1,5) == 4) {
                    Console.WriteLine($"{global.pokemon[x].name} is fully Paralyzed!");
                    return true;
                } break;
            case "Frozen":
                if (global.rand.Next(1,6) == 5) {
                    Console.WriteLine($"{global.pokemon[x].name} has thawed out!");
                    global.pokemon[x].status = "Normal";
                } else {
                    Console.WriteLine("An Ice Ball surrounds the Frozen Pokemon.");
                } return true;
        }
        if (global.pokemon[x].roosting) {
            global.pokemon[x].type2 = "Flying";
            global.pokemon[x].roosting = false;
        }

        if (global.pokemon[x].flinching) {
            Console.WriteLine($"{global.pokemon[x].name} flinched!");
            global.pokemon[x].flinching = false;
            return true;
        }

        return false;
    }


    public static void statusMoves(int x, string name, int accuracy) {
        int y = 0;
        if (x == 0)
            y = 1;

        if (hasHit(accuracy)) {
            switch (name) {
                case "Thunder Wave":
                    if (global.pokemon[y].status == "Normal") {
                        Console.WriteLine($"{global.pokemon[y].name} has been Paralyzed!");
                        global.pokemon[y].speed /= 2;
                        global.pokemon[y].status = "Paralyzed";
                    } else {
                        Console.WriteLine($"{global.pokemon[y].name} is already {global.pokemon[y].status}!");
                    } break;
                case "Screech":
                    if (global.red_defense_stage > -6) {
                        Console.WriteLine($"{global.pokemon[y].name}'s Defense harshly fell!");
                        global.pokemon[y].defense /= 2;
                        global.red_defense_stage -= 2;
                    } else {
                        Console.WriteLine($"{global.pokemon[y].name}'s Defense is as low as it goes!");
                    }
                    break;
                case "Iron Defense":
                    if (global.blue_defense_stage < 6) {
                        Console.WriteLine($"{global.pokemon[x].name}'s Defense sharply rose!");
                        global.pokemon[x].defense *= 2;
                        global.blue_defense_stage += 2;
                    } else {
                        Console.WriteLine($"{global.pokemon[y].name}'s Defense is as high as it goes!");
                    }
                    break;
                case "Roost":
                    Console.WriteLine($"{global.pokemon[x].name}'s HP was restored.");
                    if (global.pokemon[x].health * 2 >= global.pokemon[x].maxHealth)
                        global.pokemon[x].health = global.pokemon[x].maxHealth;
                    else
                        global.pokemon[x].health *= 2;
                    if (global.pokemon[x].type2 == "Flying") {
                        global.pokemon[x].type2 = "None";
                        global.pokemon[x].roosting = true;
                    }
                    break;
        }
        }
    }

    public static bool hasWon(int x) {
        if (global.pokemon[x].health <= 0) {
            Console.WriteLine($"{global.pokemon[x].name} has fainted!");
            return true;
        } else {
            return false;
        }
    }

    public static void fight(int x) {
        int y = 0;
        if (x == 0)
            y = 1;
        int dmg = 0;

        while (true) {
            Console.WriteLine($"\n{global.pokemon[x].name}   |   Status: {global.pokemon[x].status}\nHP: {global.pokemon[x].health}/{global.pokemon[x].maxHealth}");
            Console.WriteLine($"1: {global.moves[global.pokemon[x].move1].name} {global.moves[global.pokemon[x].move1].PP}/{global.moves[global.pokemon[x].move1].maxPP}  |   2: {global.moves[global.pokemon[x].move2].name} {global.moves[global.pokemon[x].move2].PP}/{global.moves[global.pokemon[x].move2].maxPP}\n3: {global.moves[global.pokemon[x].move3].name} {global.moves[global.pokemon[x].move3].PP}/{global.moves[global.pokemon[x].move3].maxPP}  |   4: {global.moves[global.pokemon[x].move4].name} {global.moves[global.pokemon[x].move4].PP}/{global.moves[global.pokemon[x].move4].maxPP}\n");
            try {
                int input = Int32.Parse(Console.ReadLine().Trim());
                if (input != 1 && input != 2 && input != 3 && input != 4) {
                    Console.WriteLine("Enter a number between 1 and 4.");
                } else {
                    if (!statusEffects(x, global.pokemon[x].status)) {
                        switch(input) {
                            case 1:
                                if (global.moves[global.pokemon[x].move1].PP == 0) {
                                    Console.WriteLine("No more PP left! Cannot use move!");
                                } else {
                                        if (global.moves[global.pokemon[x].move1].category == "Status") {
                                            statusMoves(x, global.moves[global.pokemon[x].move1].name, global.moves[global.pokemon[x].move1].accuracy);
                                        } else {
                                            Console.WriteLine($"{global.pokemon[x].name} uses {global.moves[global.pokemon[x].move1].name}!");
                                            dmg = damage(x, global.moves[global.pokemon[x].move1].power, global.moves[global.pokemon[x].move1].type, global.moves[global.pokemon[x].move1].category, global.moves[global.pokemon[x].move1].crit, global.moves[global.pokemon[x].move1].accuracy, global.moves[global.pokemon[x].move1].flinch, global.moves[global.pokemon[x].move1].freeze);
                                        } global.moves[global.pokemon[x].move1].PP -= 1;
                                } break;
                            case 2:
                                if (global.moves[global.pokemon[x].move2].PP == 0) {
                                    Console.WriteLine("No more PP left! Cannot use move!");
                                } else {
                                    if (global.moves[global.pokemon[x].move2].category == "Status") {
                                        statusMoves(x, global.moves[global.pokemon[x].move2].name, global.moves[global.pokemon[x].move2].accuracy);
                                    } else {
                                        Console.WriteLine($"{global.pokemon[x].name} uses {global.moves[global.pokemon[x].move1].name}!");
                                        dmg = damage(x, global.moves[global.pokemon[x].move2].power, global.moves[global.pokemon[x].move2].type, global.moves[global.pokemon[x].move2].category, global.moves[global.pokemon[x].move2].crit, global.moves[global.pokemon[x].move2].accuracy, global.moves[global.pokemon[x].move2].flinch, global.moves[global.pokemon[x].move2].freeze);
                                    } global.moves[global.pokemon[x].move2].PP -= 1;
                                } break;
                            case 3:
                                if (global.moves[global.pokemon[x].move3].PP == 0) {
                                    Console.WriteLine("No more PP left! Cannot use move!");
                                } else {
                                    if (global.moves[global.pokemon[x].move3].category == "Status") {
                                        statusMoves(x, global.moves[global.pokemon[x].move3].name, global.moves[global.pokemon[x].move3].accuracy);
                                    } else {
                                        Console.WriteLine($"{global.pokemon[x].name} uses {global.moves[global.pokemon[x].move3].name}!");
                                        dmg = damage(x, global.moves[global.pokemon[x].move3].power, global.moves[global.pokemon[x].move3].type, global.moves[global.pokemon[x].move3].category, global.moves[global.pokemon[x].move3].crit, global.moves[global.pokemon[x].move3].accuracy, global.moves[global.pokemon[x].move3].flinch, global.moves[global.pokemon[x].move3].freeze);
                                    } global.moves[global.pokemon[x].move3].PP -= 1;
                                } break;
                            case 4:
                                if (global.moves[global.pokemon[x].move4].PP == 0) {
                                    Console.WriteLine("No more PP left! Cannot use move!");
                                } else {
                                    if (global.moves[global.pokemon[x].move2].category == "Status") {
                                        statusMoves(x, global.moves[global.pokemon[x].move4].name, global.moves[global.pokemon[x].move4].accuracy);
                                    } else {
                                        Console.WriteLine($"{global.pokemon[x].name} uses {global.moves[global.pokemon[x].move4].name}!");
                                        dmg = damage(x, global.moves[global.pokemon[x].move4].power, global.moves[global.pokemon[x].move4].type, global.moves[global.pokemon[x].move4].category, global.moves[global.pokemon[x].move4].crit, global.moves[global.pokemon[x].move4].accuracy, global.moves[global.pokemon[x].move4].flinch, global.moves[global.pokemon[x].move4].freeze);
                                    } global.moves[global.pokemon[x].move4].PP -= 1;
                                } break;
                        }
                    if (dmg != 0) {
                        global.pokemon[y].health -= dmg;
                        Console.WriteLine($"It delt {dmg} damage!");
                    }
                    break;
                    } else {
                        break;
                    }
                }
                
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

    }
    public static void Main(String[] args) {
        while (true) {
            if (global.pokemon[0].speed > global.pokemon[1].speed) {
                fight(0);
                if (hasWon(1)) {
                    Console.WriteLine("Trainer Red has won!");
                    break;
                }
                fight(1);
                if (hasWon(0)) {
                    Console.WriteLine("Trainer Blue has won!");
                    break;
                }
            } else {
                fight(1);
                if (hasWon(0)) {
                    Console.WriteLine("Trainer Blue has won!");
                    break;
                }
                fight(0);
                if (hasWon(1)) {
                    Console.WriteLine("Trainer Red has won!");
                    break;
                }
            }
            global.turn += 1;
        }

    }
}