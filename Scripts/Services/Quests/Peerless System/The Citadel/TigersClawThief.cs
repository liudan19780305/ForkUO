using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a black order thief corpse")] 
    public class TigersClawThief : BaseCreature
    {
        [Constructable]
        public TigersClawThief()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "Black Order Thief";
            this.Title = "of the Tiger's Claw Sect";
            this.Female = Utility.RandomBool();
            this.Race = Race.Human;
            this.Hue = this.Race.RandomSkinHue();
            this.HairItemID = this.Race.RandomHair(this.Female);
            this.HairHue = this.Race.RandomHairHue();
            this.Race.RandomFacialHair(this);
			
            this.AddItem(new ThighBoots(0x51D));
            this.AddItem(new Wakizashi());
            this.AddItem(new FancyShirt(0x51D));
            this.AddItem(new StuddedMempo());
            this.AddItem(new JinBaori(0x69));
			
            Item item;
			
            item = new StuddedGloves();
            item.Hue = 0x69;
            this.AddItem(item);
			
            item = new LeatherNinjaPants();
            item.Hue = 0x51D;
            this.AddItem(item);			
			
            item = new LightPlateJingasa();
            item.Hue = 0x51D;
            this.AddItem(item);
				
            // TODO quest items

            this.SetStr(225, 275);
            this.SetDex(175, 275);
            this.SetInt(85, 105);

            this.SetHits(250, 275);

            this.SetDamage(14, 22);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 35, 60);
            this.SetResistance(ResistanceType.Fire, 45, 65);
            this.SetResistance(ResistanceType.Cold, 25, 45);
            this.SetResistance(ResistanceType.Poison, 40, 60);
            this.SetResistance(ResistanceType.Energy, 40, 65);
                  
            this.SetSkill(SkillName.MagicResist, 80.0, 100.0);
            this.SetSkill(SkillName.Tactics, 115.0, 130.0);
            this.SetSkill(SkillName.Wrestling, 95.0, 120.0);
            this.SetSkill(SkillName.Anatomy, 105.0, 120.0);
            this.SetSkill(SkillName.Fencing, 78.0, 100.0);
            this.SetSkill(SkillName.Swords, 90.1, 105.0);
            this.SetSkill(SkillName.Ninjitsu, 90.0, 120.0);
            this.SetSkill(SkillName.Hiding, 100.0, 120.0);
            this.SetSkill(SkillName.Stealth, 100.0, 120.0);

            this.Fame = 5000;
            this.Karma = -5000;

            this.VirtualArmor = 58;
        }

        public TigersClawThief(Serial serial)
            : base(serial)
        {
        }

        public override bool AlwaysMurderer
        {
            get
            {
                return true;
            }
        }
        public override bool ShowFameTitle
        {
            get
            {
                return false;
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.AosFilthyRich, 4);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}