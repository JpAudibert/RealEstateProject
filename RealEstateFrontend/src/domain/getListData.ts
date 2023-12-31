import axios from 'axios';
import { Property } from './property';

const DEFAULT_DATA: Property[] = [
  {
    id: 1,
    imageUrl: 'https://bit.ly/2Z4KKcF',
    imageAlt: 'Rear view of modern home with pool',
    type: 'Para Venda',
    name: 'Casa de Praia em Guarujá',
    address: 'Rua 1',
    number: 1,
    city: 'São Paulo',
    state: 'SP',
    zip: '00000-000',
    bedrooms: 1,
    bathrooms: 1,
    squareFeet: 1,
    price: 1000,
    garage: 1,
    description: 'Descrição 1',
    dateAdded: new Date(),
    leaseValue: {
      rent: 'R$ 1,00',
      securityDeposit: 'R$ 1,00',
      leaseDuration: '12 meses',
    },
    amenities: [
      { name: 'Ar Condicionado', value: true },
      { name: 'Sótão', value: true },
      { name: 'Piscina', value: true },
      { name: 'Churrasqueira', value: true },
    ],

    images: [
      {
        url: 'https://bit.ly/2Z4KKcF',
        alt: 'Rear view of modern home with pool',
      },
    ],
  },
  {
    id: 2,
    imageUrl: 'https://bit.ly/2Z4KKcF',
    imageAlt: 'Rear view of modern home with pool',
    type: 'Para Venda',
    name: 'Casa de Praia em Guarujá',
    address: 'Rua 1',
    number: 1,
    city: 'São Paulo',
    state: 'SP',
    zip: '00000-000',
    bedrooms: 1,
    bathrooms: 1,
    squareFeet: 1,
    price: 1000,
    garage: 1,
    description: 'Descrição 1',
    dateAdded: new Date(),
    leaseValue: {
      rent: 'R$ 1,00',
      securityDeposit: 'R$ 1,00',
      leaseDuration: '12 meses',
    },
    amenities: [
      { name: 'Ar Condicionado', value: true },
      { name: 'Sótão', value: true },
      { name: 'Piscina', value: true },
      { name: 'Churrasqueira', value: true },
    ],

    images: [
      {
        url: 'https://bit.ly/2Z4KKcF',
        alt: 'Rear view of modern home with pool',
      },
    ],
  },
  {
    id: 3,
    imageUrl: 'https://bit.ly/2Z4KKcF',
    imageAlt: 'Rear view of modern home with pool',
    type: 'Para Venda',
    name: 'Casa de Praia em Guarujá',
    address: 'Rua 1',
    number: 1,
    city: 'São Paulo',
    state: 'SP',
    zip: '00000-000',
    bedrooms: 1,
    bathrooms: 1,
    squareFeet: 1,
    price: 1000,
    garage: 1,
    description: 'Descrição 1',
    dateAdded: new Date('2020-01-01 00:00:00'),
    leaseValue: {
      rent: 'R$ 1,00',
      securityDeposit: 'R$ 1,00',
      leaseDuration: '12 meses',
    },
    amenities: [
      { name: 'Ar Condicionado', value: true },
      { name: 'Sótão', value: true },
      { name: 'Piscina', value: true },
      { name: 'Churrasqueira', value: true },
    ],

    images: [
      {
        url: 'https://bit.ly/2Z4KKcF',
        alt: 'Rear view of modern home with pool',
      },
    ],
  },
  {
    id: 4,
    imageUrl: 'https://bit.ly/2Z4KKcF',
    imageAlt: 'Rear view of modern home with pool',
    type: 'Para Venda',
    name: 'Casa de Praia em Guarujá',
    address: 'Rua 1',
    number: 1,
    city: 'São Paulo',
    state: 'SP',
    zip: '00000-000',
    bedrooms: 1,
    bathrooms: 1,
    squareFeet: 1,
    price: 1000,
    garage: 1,
    description: 'Descrição 1',
    dateAdded: new Date(),
    leaseValue: {
      rent: 'R$ 1,00',
      securityDeposit: 'R$ 1,00',
      leaseDuration: '12 meses',
    },
    amenities: [
      { name: 'Ar Condicionado', value: true },
      { name: 'Sótão', value: true },
      { name: 'Piscina', value: true },
      { name: 'Churrasqueira', value: true },
    ],

    images: [
      {
        url: 'https://bit.ly/2Z4KKcF',
        alt: 'Rear view of modern home with pool',
      },
    ],
  },
  {
    id: 5,
    imageUrl: 'https://bit.ly/2Z4KKcF',
    imageAlt: 'Rear view of modern home with pool',
    type: 'Para Venda',
    name: 'Casa de Praia em Guarujá',
    address: 'Rua 1',
    number: 1,
    city: 'São Paulo',
    state: 'SP',
    zip: '00000-000',
    bedrooms: 1,
    bathrooms: 1,
    squareFeet: 1,
    price: 1000,
    garage: 1,
    description: 'Descrição 1',
    dateAdded: new Date(),
    leaseValue: {
      rent: 'R$ 1,00',
      securityDeposit: 'R$ 1,00',
      leaseDuration: '12 meses',
    },
    amenities: [
      { name: 'Ar Condicionado', value: true },
      { name: 'Sótão', value: true },
      { name: 'Piscina', value: true },
      { name: 'Churrasqueira', value: true },
    ],

    images: [
      {
        url: 'https://bit.ly/2Z4KKcF',
        alt: 'Rear view of modern home with pool',
      },
    ],
  },
  {
    id: 6,
    imageUrl: 'https://bit.ly/2Z4KKcF',
    imageAlt: 'Rear view of modern home with pool',
    type: 'Para Venda',
    name: 'Casa de Praia em Guarujá',
    address: 'Rua 1',
    number: 1,
    city: 'São Paulo',
    state: 'SP',
    zip: '00000-000',
    bedrooms: 1,
    bathrooms: 1,
    squareFeet: 1,
    price: 1000,
    garage: 1,
    description: 'Descrição 1',
    dateAdded: new Date(),
    leaseValue: {
      rent: 'R$ 1,00',
      securityDeposit: 'R$ 1,00',
      leaseDuration: '12 meses',
    },
    amenities: [
      { name: 'Ar Condicionado', value: true },
      { name: 'Sótão', value: true },
      { name: 'Piscina', value: true },
      { name: 'Churrasqueira', value: true },
    ],

    images: [
      {
        url: 'https://bit.ly/2Z4KKcF',
        alt: 'Rear view of modern home with pool',
      },
    ],
  },
  {
    id: 7,
    imageUrl: 'https://bit.ly/2Z4KKcF',
    imageAlt: 'Rear view of modern home with pool',
    type: 'Para Venda',
    name: 'Casa de Praia em Guarujá',
    address: 'Rua 1',
    number: 1,
    city: 'São Paulo',
    state: 'SP',
    zip: '00000-000',
    bedrooms: 1,
    bathrooms: 1,
    squareFeet: 1,
    price: 1000,
    garage: 1,
    description: 'Descrição 1',
    dateAdded: new Date('2020-01-01 00:00:00'),
    leaseValue: {
      rent: 'R$ 1,00',
      securityDeposit: 'R$ 1,00',
      leaseDuration: '12 meses',
    },
    amenities: [
      { name: 'Ar Condicionado', value: true },
      { name: 'Sótão', value: true },
      { name: 'Piscina', value: true },
      { name: 'Churrasqueira', value: true },
    ],
    images: [
      {
        url: 'https://bit.ly/2Z4KKcF',
        alt: 'Rear view of modern home with pool',
      },
    ],
  },
  {
    id: 8,
    imageUrl: 'https://bit.ly/2Z4KKcF',
    imageAlt: 'Rear view of modern home with pool',
    type: 'Para Venda',
    name: 'Casa de Praia em Guarujá',
    address: 'Rua 1',
    number: 1,
    city: 'São Paulo',
    state: 'SP',
    zip: '00000-000',
    bedrooms: 1,
    bathrooms: 1,
    squareFeet: 1,
    price: 1000,
    garage: 1,
    description: 'Descrição 1',
    dateAdded: new Date(),
    leaseValue: {
      rent: 'R$ 1,00',
      securityDeposit: 'R$ 1,00',
      leaseDuration: '12 meses',
    },
    amenities: [
      { name: 'Ar Condicionado', value: true },
      { name: 'Sótão', value: true },
      { name: 'Piscina', value: true },
      { name: 'Churrasqueira', value: true },
    ],
    images: [
      {
        url: 'https://bit.ly/2Z4KKcF',
        alt: 'Rear view of modern home with pool',
      },
    ],
  },
];

const getListData = async (type: string, filter: string): Promise<Property[]> => {
  try {
    const response = await axios.get(
      `http://localhost:8888/api/property?type=${type}&filter=${filter}`,
    );

    if (response.data.length === 0) {
      return DEFAULT_DATA;
    }
    return response.data;
  } catch (error) {
    console.log(error);
  }

  return [];
};

const getHouseData = async (id: number) => {
  try {
    const response = await axios.get('http://localhost:8888/api/property/' + id);
    return response.data;
  } catch (error) {
    console.log(error);
  }
  return null;
};

const getLeaseValue = async (id: number) => {
  try {
    const response = await axios.get('http://localhost:8888/api/leaseValue/' + id);
    return response.data;
  } catch (error) {
    console.log(error);
  }
  return null;
};

const getAmenity = async (id: number) => {
  try {
    const response = await axios.get('http://localhost:8888/api/amenity/' + id);
    return response.data;
  } catch (error) {
    console.log(error);
  }
  return null;
};

export { getListData, getLeaseValue, getAmenity, getHouseData };
