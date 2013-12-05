using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverControl_v3
{
    public static class Tools
    {
        //return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        public static Byte MapIntToByte(Int64 value, Int64 source_min, Int64 source_max, Byte target_min, Byte target_max, Double dead_zone)
        {
            // the result
            Byte    result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToByte((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }

        public static Int16 MapIntToInt16(Int64 value, Int64 source_min, Int64 source_max, Int16 target_min, Int16 target_max, Double dead_zone)
        {
            // the result
            Int16   result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToInt16((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }
        public static Int32 MapIntToInt32(Int64 value, Int64 source_min, Int64 source_max, Int32 target_min, Int32 target_max, Double dead_zone)
        {
            // the result
            Int32   result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToInt32((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }
        public static Int64 MapIntToInt64(Int64 value, Int64 source_min, Int64 source_max, Int64 target_min, Int64 target_max, Double dead_zone)
        {
            // the result
            Int64   result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToInt64((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }

        public static UInt16 MapIntToUInt16(Int64 value, Int64 source_min, Int64 source_max, UInt16 target_min, UInt16 target_max, Double dead_zone)
        {
            // the result
            UInt16  result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToUInt16((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }
        public static UInt32 MapIntToUInt32(Int64 value, Int64 source_min, Int64 source_max, UInt32 target_min, UInt32 target_max, Double dead_zone)
        {
            // the result
            UInt32  result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToUInt32((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }

        public static Int16 MapUIntToInt16(Int64 value, UInt64 source_min, UInt64 source_max, Int16 target_min, Int16 target_max, Double dead_zone)
        {
            // the result
            Int16   result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToInt16((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }
        public static Int32 MapUIntToInt32(UInt64 value, UInt64 source_min, UInt64 source_max, Int32 target_min, Int32 target_max, Double dead_zone)
        {
            // the result
            Int32   result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToInt32((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }
        public static Int64 MapUIntToInt64(UInt64 value, UInt64 source_min, UInt64 source_max, Int64 target_min, Int64 target_max, Double dead_zone)
        {
            // the result
            Int64   result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToInt64((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }

        public static UInt16 MapUIntToUInt16(UInt64 value, UInt64 source_min, UInt64 source_max, UInt16 target_min, UInt16 target_max, Double dead_zone)
        {
            // the result
            UInt16  result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToUInt16((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }
        public static UInt32 MapUIntToUInt32(UInt64 value, UInt64 source_min, UInt64 source_max, UInt32 target_min, UInt32 target_max, Double dead_zone)
        {
            // the result
            UInt32  result          = 0;
            // the adjusted values
            Int64   adj_value       = Convert.ToInt64(value);
            Int64   adj_source_min  = Convert.ToInt64(source_min);
            Int64   adj_source_max  = Convert.ToInt64(source_max);
            // calculate the result
            result  = Convert.ToUInt32((adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min);
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0;
            }
            // return the result
            return result;
        }

        public static Double MapUIntToDouble(UInt64 value, UInt64 source_min, UInt64 source_max, Double target_min, Double target_max, Double dead_zone)
        {
            // the result
            Double  result          = 0.00;
            // the adjusted values
            Double  adj_value       = Convert.ToDouble(value);
            Double  adj_source_min  = Convert.ToDouble(source_min);
            Double  adj_source_max  = Convert.ToDouble(source_max);
            // calculate the result
            result  = (adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min;
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0.00;
            }
            // return the result
            return result;
        }

        public static Double MapIntToDouble(Int64 value, Int64 source_min, Int64 source_max, Double target_min, Double target_max, Double dead_zone)
        {
            // the result
            Double  result          = 0.00;
            // the adjusted values
            Double  adj_value       = Convert.ToDouble(value);
            Double  adj_source_min  = Convert.ToDouble(source_min);
            Double  adj_source_max  = Convert.ToDouble(source_max);
            // calculate the result
            result  = (adj_value - adj_source_min) * (target_max - target_min) / (adj_source_max - adj_source_min) + target_min;
            // determine if the result is within the dead zone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // clear the result
                result = 0.00;
            }
            // return the result
            return result;
        }
        
        public static UInt32 MapDoubleToUInt32(Double value, Double source_min, Double source_max, UInt32 target_min, UInt32 target_max, UInt32 dead_zone)
        {
            // the result
            Double  result          = 0.00;
            // the adjusted values
            Double  adj_target_min  = Convert.ToDouble(target_min);
            Double  adj_target_max  = Convert.ToDouble(target_max);
            Double  adj_dead_zone   = Convert.ToDouble(dead_zone);
            // calculate the result
            result  = (value - source_min) * (adj_target_max - adj_target_min) / (source_max - source_min) + adj_target_min;
            // determine if the result is within the target type's range
            if (result < UInt32.MinValue)
            {
                // the result is below the minimum
                // save the result
                result = Convert.ToDouble(UInt32.MinValue);
            }
            else
            if (result > UInt32.MaxValue)
            {
                // the result is above the minimum
                // save the result
                result = Convert.ToDouble(UInt32.MinValue);
            }
            // determine if the result is in the deadzone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // save the result
                result = 0;
            }
            // return the result
            return Convert.ToUInt32(result);
        }
        
        public static Int32 MapDoubleToInt32(Double value, Double source_min, Double source_max, Int32 target_min, Int32 target_max, Int32 dead_zone)
        {
            // the result
            Double  result          = 0.00;
            // the adjusted values
            Double  adj_target_min  = Convert.ToDouble(target_min);
            Double  adj_target_max  = Convert.ToDouble(target_max);
            Double  adj_dead_zone   = Convert.ToDouble(dead_zone);
            // calculate the result
            result  = (value - source_min) * (adj_target_max - adj_target_min) / (source_max - source_min) + adj_target_min;
            // determine if the result is within the target type's range
            if (result < UInt32.MinValue)
            {
                // the result is below the minimum
                // save the result
                result = Convert.ToDouble(Int32.MinValue);
            }
            else
            if (result > UInt32.MaxValue)
            {
                // the result is above the minimum
                // save the result
                result = Convert.ToDouble(Int32.MinValue);
            }
            // determine if the result is in the deadzone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // save the result
                result = 0;
            }
            // return the result
            return Convert.ToInt32(result);
        }
       
        public static UInt16 MapDoubleToUInt16(Double value, Double source_min, Double source_max, UInt16 target_min, UInt16 target_max, UInt16 dead_zone)
        {
            // the result
            Double  result          = 0.00;
            // the adjusted values
            Double  adj_target_min  = Convert.ToDouble(target_min);
            Double  adj_target_max  = Convert.ToDouble(target_max);
            Double  adj_dead_zone   = Convert.ToDouble(dead_zone);
            // calculate the result
            result  = (value - source_min) * (adj_target_max - adj_target_min) / (source_max - source_min) + adj_target_min;
            // determine if the result is within the target type's range
            if (result < UInt16.MinValue)
            {
                // the result is below the minimum
                // save the result
                result = Convert.ToDouble(UInt16.MinValue);
            }
            else
            if (result > UInt16.MaxValue)
            {
                // the result is above the minimum
                // save the result
                result = Convert.ToDouble(UInt16.MinValue);
            }
            // determine if the result is in the deadzone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // save the result
                result = 0;
            }
            // return the result
            return Convert.ToUInt16(result);
        }
        
        public static Int16 MapDoubleToInt16(Double value, Double source_min, Double source_max, Int16 target_min, Int16 target_max, UInt16 dead_zone)
        {
            // the result
            Double  result          = 0.00;
            // the adjusted values
            Double  adj_target_min  = Convert.ToDouble(target_min);
            Double  adj_target_max  = Convert.ToDouble(target_max);
            Double  adj_dead_zone   = Convert.ToDouble(dead_zone);
            // calculate the result
            result  = (value - source_min) * (adj_target_max - adj_target_min) / (source_max - source_min) + adj_target_min;
            // determine if the result is within the target type's range
            if (result < Int16.MinValue)
            {
                // the result is below the minimum
                // save the result
                result = Convert.ToDouble(Int16.MinValue);
            }
            else
            if (result > Int16.MaxValue)
            {
                // the result is above the minimum
                // save the result
                result = Convert.ToDouble(Int16.MinValue);
            }
            // determine if the result is in the deadzone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // save the result
                result = 0;
            }
            // return the result
            return Convert.ToInt16(result);
        }
        
        public static Byte MapDoubleToUInt8(Double value, Double source_min, Double source_max, Byte target_min, Byte target_max, Byte dead_zone)
        {
            // the result
            Double  result          = 0.00;
            // the adjusted values
            Double  adj_target_min  = Convert.ToDouble(target_min);
            Double  adj_target_max  = Convert.ToDouble(target_max);
            Double  adj_dead_zone   = Convert.ToDouble(dead_zone);
            // calculate the result
            result  = (value - source_min) * (adj_target_max - adj_target_min) / (source_max - source_min) + adj_target_min;
            // determine if the result is within the target type's range
            if (result < Byte.MinValue)
            {
                // the result is below the minimum
                // save the result
                result = Convert.ToDouble(Byte.MinValue);
            }
            else
            if (result > Byte.MaxValue)
            {
                // the result is above the minimum
                // save the result
                result = Convert.ToDouble(Byte.MinValue);
            }
            // determine if the result is in the deadzone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // save the result
                result = 0;
            }
            // return the result
            return Convert.ToByte(result);
        }
        
        public static SByte MapDoubleToInt8(Double value, Double source_min, Double source_max, SByte target_min, SByte target_max, SByte dead_zone)
        {
            // the result
            Double  result          = 0.00;
            // the adjusted values
            Double  adj_target_min  = Convert.ToDouble(target_min);
            Double  adj_target_max  = Convert.ToDouble(target_max);
            Double  adj_dead_zone   = Convert.ToDouble(dead_zone);
            // calculate the result
            result  = (value - source_min) * (adj_target_max - adj_target_min) / (source_max - source_min) + adj_target_min;
            // determine if the result is within the target type's range
            if (result < SByte.MinValue)
            {
                // the result is below the minimum
                // save the result
                result = Convert.ToDouble(SByte.MinValue);
            }
            else
            if (result > SByte.MaxValue)
            {
                // the result is above the minimum
                // save the result
                result = Convert.ToDouble(SByte.MinValue);
            }
            // determine if the result is in the deadzone
            if (Math.Abs(result) < dead_zone)
            {
                // it is
                // save the result
                result = 0;
            }
            // return the result
            return Convert.ToSByte(result);
        }
    }
}
