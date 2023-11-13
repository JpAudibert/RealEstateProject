import axios from 'axios';
import { Property } from './property';
import { DEFAULT_DATA } from './testConstants';

const getListData = async (type: string, filter: string): Promise<Property[]> => {
  try {
    const response = await axios.get(`/real-estate/property?type=${type}&filter=${filter}`);

    if (response.data.length === 0) {
      return DEFAULT_DATA;
    }
    return response.data;
  } catch (error) {
    console.log(error);
  }

  return DEFAULT_DATA;
};

const getHouseData = async (id: number) => {
  try {
    const response = await axios.get('/real-estate/property/' + id);
    return response.data;
  } catch (error) {
    console.log(error);
  }
  return null;
};

const getRentValue = async (id: number) => {
  try {
    const response = await axios.get('/real-estate/rentValue/' + id);
    return response.data;
  } catch (error) {
    console.log(error);
  }
  return null;
};

const getAmenity = async (id: number) => {
  try {
    const response = await axios.get('/real-estate/amenity/' + id);
    return response.data;
  } catch (error) {
    console.log(error);
  }
  return null;
};

export { getListData, getRentValue, getAmenity, getHouseData };
