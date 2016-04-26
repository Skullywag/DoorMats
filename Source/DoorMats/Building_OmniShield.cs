using System;
using System.Reflection;
using Verse;
namespace DoorMats
{
    public class Building_DoorMat : Building
    {
        public override void Tick()
        {
            if (!Gen.IsHashIntervalTick(this, 10))
            {
                return;
            }
            base.Tick();
            foreach (IntVec3 current in GenAdj.OccupiedRect(this))
            {
                if (!GenGrid.Impassable(current))
                {
                    Pawn pawn = Find.Map.thingGrid.ThingAt<Pawn>(current);
                    if (pawn != null)
                    {
                        pawn.filth.GetType().GetMethod("TryDropFilth", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(pawn.filth, null);
                    }
                }
            }
        }
    }
}
