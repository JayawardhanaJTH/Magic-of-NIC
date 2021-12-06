package services;

public interface IValidate
{
    boolean Validate(String number);

    boolean IsValidLength(String number);

    boolean IsOldNumber(String number);

    boolean IsValidNumber(String number,boolean isOld);

}
