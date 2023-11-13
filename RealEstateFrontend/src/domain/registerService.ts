import axios, { AxiosResponse } from 'axios';
import { Amenity, NewProperty, Property, RentValue, SellValue } from './property';
import stringToFloat from './stringToFloat';

export const registerNewProperty = async (
  property: NewProperty,
  commercialType: string,
  amenities: Amenity[],
): Promise<AxiosResponse<Property>> => {
  const leaseRentValue = stringToFloat(property.rentValue?.rent);
  const leaseSecurityDeposit = stringToFloat(property.rentValue?.securityDeposit);
  const sellValuePrice = stringToFloat(property.sellValue?.value);
  const sellSecurityDeposit = stringToFloat(property.sellValue?.securityDeposit);

  const sellValue: SellValue = {
    value: sellValuePrice.toString(),
    securityDeposit: sellSecurityDeposit.toString(),
  };
  const rentValue: RentValue = {
    rent: leaseRentValue.toString(),
    securityDeposit: leaseSecurityDeposit.toString(),
    leaseDuration: property.rentValue?.leaseDuration ?? '',
  };
  const newPropertyWithValues = {
    ...property,
    sellValue: sellValue,
    rentValue: rentValue,
  };

  const propertyToSave: NewProperty = {
    ...newPropertyWithValues,
    commercialType,
    amenities: amenities.filter((amenity) => amenity.value),
    images: [
      {
        url: property.imageBase64,
        alt: '',
      },
    ],
  };

  return await axios.post('/real-state/property', propertyToSave);
};
