interface NewProperty {
  commercialType: string;
  imageBase64: string;
  title: string;
  description: string;
  address: string;
  number: number;
  city: string;
  state: string;
  zipCode: string;
  bedrooms: number;
  bathrooms: number;
  squareFoot: number;
  garage: number;
  rentValue?: RentValue;
  sellValue?: SellValue;
  amenities: Amenity[];
  images: PropertyImage[];
}

interface Property {
  id: number;
  commercialType: string;
  imageBase64: string;
  title: string;
  description: string;
  address: string;
  number: number;
  city: string;
  state: string;
  zipCode: string;
  bedrooms: number;
  bathrooms: number;
  squareFoot: number;
  garage: number;
  dateAdded: Date;
  rentValue?: RentValue;
  sellValue?: SellValue;
  amenities: Amenity[];
  images: PropertyImage[];
}

interface RentValue {
  rent: string;
  securityDeposit: string;
  leaseDuration: string;
}

interface SellValue {
  value: string;
  securityDeposit: string;
}

interface Amenity {
  name: string;
  value: boolean;
}

interface PropertyImage {
  url?: string;
  alt?: string;
  base64?: string;
}

const AMENITIES: Amenity[] = [
  { name: 'Ar Condicionado', value: false },
  { name: 'Sótão', value: false },
  { name: 'Piscina', value: false },
  { name: 'Churrasqueira', value: false },
  { name: 'Jardim', value: false },
  { name: 'Cozinha', value: false },
  { name: 'Lareira', value: false },
  { name: 'Garagem', value: false },
  { name: 'Elevador', value: false },
  { name: 'Portaria', value: false },
  { name: 'Segurança', value: false },
  { name: 'Cerca Elétrica', value: false },
  { name: 'Alarme', value: false },
  { name: 'Câmeras', value: false },
  { name: 'Internet', value: false },
  { name: 'TV a Cabo', value: false },
  { name: 'Área de Serviço', value: false },
  { name: 'Acesso de Cadeira de Rodas', value: false },
  { name: 'Microondas', value: false },
  { name: 'Porão', value: false },
];

const INITIAL_RENT_VALUE: RentValue = {
  rent: '0',
  securityDeposit: '0',
  leaseDuration: '0',
};

const INITIAL_SELL_VALUE: SellValue = {
  value: '0',
  securityDeposit: '0',
};

const INITITAL_STATE: NewProperty = {
  commercialType: '',
  imageBase64: '',
  title: '',
  address: '',
  number: 0,
  city: '',
  state: '',
  zipCode: '',
  bedrooms: 0,
  bathrooms: 0,
  squareFoot: 0,
  garage: 0,
  description: '',
  rentValue: INITIAL_RENT_VALUE,
  sellValue: INITIAL_SELL_VALUE,
  amenities: AMENITIES,
  images: [],
};

const INITITAL_PROPERTY_STATE: Property = {
  id: 0,
  commercialType: '',
  imageBase64: '',
  title: '',
  address: '',
  number: 0,
  city: '',
  state: '',
  zipCode: '',
  bedrooms: 0,
  bathrooms: 0,
  squareFoot: 0,
  garage: 0,
  description: '',
  dateAdded: new Date(),
  rentValue: INITIAL_RENT_VALUE,
  sellValue: INITIAL_SELL_VALUE,
  amenities: AMENITIES,
  images: [],
};

export {
  INITITAL_PROPERTY_STATE,
  INITITAL_STATE,
  INITIAL_RENT_VALUE as INITIAL_LEASE_VALUE,
  INITIAL_SELL_VALUE,
  AMENITIES as amenities,
};

export type { NewProperty, Property, RentValue, SellValue, Amenity };
