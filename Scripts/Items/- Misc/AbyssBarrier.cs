using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Regions;

namespace Server.Items
{
    public class AbyssBarrier : Item
    {
      
        [Constructable]
        public AbyssBarrier() : base(0x49E)
        {
            Movable = false;
            Visible = false;
        }

        public override bool OnMoveOver(Mobile m)
        {
            PlayerMobile mobile = m as PlayerMobile;

            if (m.AccessLevel > AccessLevel.Player)
                return true;
            {

                if (mobile.AbyssEntry == false)
                {
                    m.SendLocalizedMessage(1112226);
                    return false;
                }
                else
                {
                    m.SendLocalizedMessage(1113708);
                    return true;
                }
            }
        }

        public AbyssBarrier(Serial serial): base(serial)
        {
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

	
