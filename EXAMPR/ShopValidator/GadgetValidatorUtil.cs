using System;
namespace ShopValidator;

public class GadgetValidatorUtil
{
    public Boolean validateGadgetID(string gadgetID)
    {
        if(gadgetID.Length != 4)
        {
            throw new InvalidGadgetException("Invalid gadget ID");
        }
        if (!char.IsUpper(gadgetID[0]))
        {
            throw new InvalidGadgetException("Invalid gadget ID");
        }
        for(int i = 1; i < 4; i++)
        {
            if (!char.IsDigit(gadgetID[i]))
            {
                throw new InvalidGadgetException("Invalid gadget ID");
            }
        }
        return true;
    }

    public Boolean validateWarrantyPeriod(int period)
    {
        if(period < 6 || period > 36)
        {
            throw new InvalidGadgetException("Invalid warranty period");
        }
        return true;
    }
}