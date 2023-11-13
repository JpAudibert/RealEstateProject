'use client';

import {
  Box,
  Button,
  Checkbox,
  Container,
  Divider,
  FormControl,
  FormLabel,
  Grid,
  GridItem,
  HStack,
  Input,
  InputGroup,
  InputLeftElement,
  Text,
  useRadioGroup,
} from '@chakra-ui/react';
import axios from 'axios';
import Head from 'next/head';
import router from 'next/router';
import React, { useCallback, useMemo, useState } from 'react';
import {
  FaCamera,
  FaDollarSign,
  FaFileInvoiceDollar,
  FaHouseUser,
  FaMapMarkedAlt,
  FaTree,
} from 'react-icons/fa';
import Categories from '../components/Categories/Categories';
import brazilStates from '../domain/brazilStates';
import formatCep from '../domain/cepFormatter';
import {
  amenities,
  Amenity,
  INITITAL_STATE,
  RentValue,
  NewProperty,
  SellValue,
} from '../domain/property';
import stringToFloat from '../domain/stringToFloat';
import { formatBrlPrice } from '../domain/formatPrice';
import { registerNewProperty } from '../domain/registerService';

interface Option {
  value: string;
  image: string;
}

const options: Option[] = [
  { value: 'Venda', image: 'Para Venda' },
  { value: 'Aluguel', image: 'Para Alugar' },
];

const NewProperty: React.FC = () => {
  const [property, setProperty] = useState<NewProperty>(INITITAL_STATE);
  const [amenitiesState, setAmenitiesState] = useState<Amenity[]>(amenities);
  const [buttonPressed, setButtonPressed] = useState(false);
  const [leaseState, setLeaseState] = useState(false);
  const [radioValue, setRadioValue] = useState<string>('Venda');

  const handleRadioChange = useCallback((value: string) => {
    setRadioValue(value);
    setLeaseState(value === 'Aluguel');
  }, []);

  const { getRootProps, getRadioProps } = useRadioGroup({
    name: 'framework',
    defaultValue: 'Venda',
    onChange: handleRadioChange,
  });

  const group = getRootProps();

  const isStateValid = useMemo(() => {
    return (
      brazilStates.map((state) => state.abbreviation).includes(property.state) ||
      brazilStates.map((state) => state.name).includes(property.state)
    );
  }, [property.state]);

  const isZipValid = useMemo(() => {
    return property.zipCode.length === 9 && property.zipCode.includes('-');
  }, [property.zipCode]);

  const validateForm = useCallback(() => {
    if (
      property.title === '' ||
      property.address === '' ||
      property.city === '' ||
      !isStateValid ||
      !isZipValid
    ) {
      return false;
    }

    return true;
  }, [property, isStateValid, isZipValid]);

  const handleSubmit = useCallback(() => {
    if (validateForm()) {
      registerNewProperty(property, radioValue, amenitiesState).then((e) =>
        router.push(`/property/${e.data.id}`),
      );
    }
    setButtonPressed(true);
  }, [validateForm, property, radioValue, amenitiesState]);

  return (
    <>
      <Head>
        <title>Add Property</title>
      </Head>
      <Container
        borderWidth="1px"
        maxW="container.xl"
        backgroundColor="gray.200"
        textAlign="center"
        borderRadius="lg"
      >
        <Box padding="20px">
          <Text fontSize="5xl">Adicionar Imóvel</Text>
          <Divider orientation="horizontal" />
          <Box>
            <HStack {...group} justifyContent="center">
              {options.map((values) => {
                const radio = getRadioProps({ value: values.value });
                return (
                  <Categories key={values.value} {...radio}>
                    <div>{values.image}</div>
                  </Categories>
                );
              })}
            </HStack>
          </Box>
          <Grid
            marginTop="10"
            h="120px"
            templateRows="repeat(4,1fr)"
            templateColumns="repeat(12, 1fr)"
            gap={4}
          >
            <GridItem rowSpan={2} colSpan={4} textAlign="left">
              <Box width="min-content">
                <FaHouseUser fontSize="50px" />
              </Box>
              <Text fontSize="2xl">Informações do Imóvel</Text>
            </GridItem>
            <GridItem colSpan={8}>
              <FormControl variant="floating">
                <Input
                  paddingLeft="10px"
                  borderRadius={'md'}
                  variant="flushed"
                  type="text"
                  value={property.title}
                  placeholder=" "
                  bg="gray.100"
                  onChange={(e) =>
                    setProperty((state) => {
                      return { ...state, title: e.target.value };
                    })
                  }
                />
                <FormLabel>Nome do Imóvel</FormLabel>
              </FormControl>
            </GridItem>
            <GridItem colSpan={2}>
              <FormControl variant="floating">
                <Input
                  paddingLeft="10px"
                  bg="gray.100"
                  borderRadius={'md'}
                  variant="flushed"
                  type="number"
                  value={property.bedrooms}
                  max={10}
                  placeholder=" "
                  _placeholder={{ color: 'gray.500' }}
                  onChange={(e) =>
                    setProperty((state) => {
                      return { ...state, bedrooms: Number(e.target.value) };
                    })
                  }
                />
                <FormLabel>Quartos</FormLabel>
              </FormControl>
            </GridItem>
            <GridItem colSpan={2}>
              <FormControl variant="floating">
                <Input
                  paddingLeft="10px"
                  bg="gray.100"
                  borderRadius={'md'}
                  variant="flushed"
                  type="number"
                  max={5}
                  value={property.bathrooms}
                  placeholder=" "
                  _placeholder={{ color: 'gray.500' }}
                  onChange={(e) =>
                    setProperty((state) => {
                      return { ...state, bathrooms: Number(e.target.value) };
                    })
                  }
                />
                <FormLabel>Banheiros</FormLabel>
              </FormControl>
            </GridItem>
            <GridItem colSpan={2}>
              <FormControl variant="floating">
                <Input
                  paddingLeft="10px"
                  bg="gray.100"
                  borderRadius={'md'}
                  variant="flushed"
                  type="number"
                  value={property.squareFoot}
                  placeholder=" "
                  _placeholder={{ color: 'gray.500' }}
                  onChange={(e) =>
                    setProperty((state) => {
                      return { ...state, squareFoot: Number(e.target.value) };
                    })
                  }
                />
                <FormLabel>Área</FormLabel>
              </FormControl>
            </GridItem>
            <GridItem colSpan={2}>
              <FormControl variant="floating">
                <Input
                  paddingLeft="10px"
                  bg="gray.100"
                  borderRadius={'md'}
                  variant="flushed"
                  type="number"
                  value={property.garage}
                  placeholder=" "
                  _placeholder={{ color: 'gray.500' }}
                  onChange={(e) =>
                    setProperty((state) => {
                      return { ...state, garage: Number(e.target.value) };
                    })
                  }
                />
                <FormLabel>Garagem</FormLabel>
              </FormControl>
            </GridItem>
          </Grid>
          <Box h="3px" bg={'blackAlpha.100'} marginBottom="8" marginTop="8" />
          <Grid h="120px" templateRows="repeat(5,1fr)" templateColumns="repeat(12, 1fr)" gap={4}>
            <GridItem rowSpan={3} colSpan={4} textAlign="left">
              <Box width="min-content">
                <FaMapMarkedAlt fontSize="50px" />
              </Box>
              <Text fontSize="2xl" flex="1">
                Endereço do Imóvel
              </Text>
            </GridItem>
            <GridItem colSpan={2}>
              <FormControl variant="floating">
                <Input
                  paddingLeft="10px"
                  bg="gray.100"
                  borderRadius={'md'}
                  variant="flushed"
                  type="number"
                  value={property.zipCode.replace(/\D/g, '')}
                  placeholder=" "
                  _placeholder={{ color: 'gray.500' }}
                  isInvalid={!isZipValid && (property.zipCode !== '' || buttonPressed)}
                  errorBorderColor="red.300"
                  onChange={(e) =>
                    setProperty((state) => {
                      return { ...state, zipCode: formatCep(e.target.value) };
                    })
                  }
                />
                <FormLabel>CEP</FormLabel>
              </FormControl>
            </GridItem>
            <GridItem colSpan={2}>
              <FormControl variant="floating">
                <Input
                  paddingLeft="10px"
                  bg="gray.100"
                  borderRadius={'md'}
                  variant="flushed"
                  type="search"
                  value={property.city}
                  placeholder=" "
                  _placeholder={{ color: 'gray.500' }}
                  onChange={(e) =>
                    setProperty((state) => {
                      return { ...state, city: e.target.value };
                    })
                  }
                />
                <FormLabel>Cidade</FormLabel>
              </FormControl>
            </GridItem>
            <GridItem colSpan={2}>
              <FormControl variant="floating">
                <Input
                  paddingLeft="10px"
                  bg="gray.100"
                  borderRadius={'md'}
                  variant="flushed"
                  type="search"
                  value={property.state}
                  placeholder=" "
                  _placeholder={{ color: 'gray.500' }}
                  isInvalid={!isStateValid && (property.state !== '' || buttonPressed)}
                  errorBorderColor="red.300"
                  onChange={(e) =>
                    setProperty((state) => {
                      return { ...state, state: e.target.value };
                    })
                  }
                />
                <FormLabel>Estado</FormLabel>
              </FormControl>
            </GridItem>
            <GridItem colSpan={6}>
              <FormControl variant="floating">
                <Input
                  paddingLeft="10px"
                  borderRadius={'md'}
                  variant="flushed"
                  type="text"
                  value={property.address}
                  placeholder=" "
                  _placeholder={{ color: 'gray.500' }}
                  bg="gray.100"
                  onChange={(e) =>
                    setProperty((state) => {
                      return { ...state, address: e.target.value };
                    })
                  }
                />
                <FormLabel>Endereço</FormLabel>
              </FormControl>
            </GridItem>
            <GridItem colSpan={2}>
              <FormControl variant="floating">
                <Input
                  paddingLeft="10px"
                  bg="gray.100"
                  borderRadius={'md'}
                  variant="flushed"
                  type="number"
                  value={property.number}
                  placeholder=" "
                  _placeholder={{ color: 'gray.500' }}
                  onChange={(e) =>
                    setProperty((state) => {
                      return { ...state, number: Number(e.target.value) };
                    })
                  }
                />
                <FormLabel>Número</FormLabel>
              </FormControl>
            </GridItem>
          </Grid>

          {leaseState ? (
            <>
              <Box h="3px" bg={'blackAlpha.100'} marginBottom="8" marginTop="8" />
              <Grid
                h="120px"
                templateRows="repeat(2,1fr)"
                templateColumns="repeat(18, 1fr)"
                gap={4}
              >
                <GridItem rowSpan={2} colSpan={6} textAlign="left">
                  <Box width="min-content">
                    <FaFileInvoiceDollar fontSize="50px" />
                  </Box>
                  <Text fontSize="2xl" flex="1">
                    Locação
                  </Text>
                </GridItem>
                <GridItem colSpan={4}>
                  <Text fontSize="md" flex="1">
                    Valor do aluguel
                  </Text>
                </GridItem>
                <GridItem colSpan={4}>
                  <Text fontSize="md" flex="1">
                    Valor do Adiantamento
                  </Text>
                </GridItem>
                <GridItem colSpan={4}>
                  <Text fontSize="md" flex="1">
                    Duração do contrato
                  </Text>
                </GridItem>
                <GridItem colSpan={4}>
                  <InputGroup>
                    <InputLeftElement pointerEvents="none" color="gray.300" fontSize="1.2em" />
                    <Input
                      bg="gray.100"
                      borderRadius={'md'}
                      variant="flushed"
                      type="text"
                      value={new Intl.NumberFormat('pt-BR', {
                        style: 'currency',
                        currency: 'BRL',
                      }).format(stringToFloat(property.rentValue?.rent))}
                      placeholder="Aluguel"
                      _placeholder={{ color: 'gray.500' }}
                      onChange={(e) =>
                        setProperty((property) => {
                          return {
                            ...property,
                            rentValue: { ...property.rentValue!, rent: e.target.value },
                          };
                        })
                      }
                    />
                  </InputGroup>
                </GridItem>
                <GridItem colSpan={4}>
                  <InputGroup>
                    <InputLeftElement pointerEvents="none" color="gray.300" fontSize="1.2em" />
                    <Input
                      bg="gray.100"
                      borderRadius={'md'}
                      variant="flushed"
                      type="text"
                      value={formatBrlPrice(stringToFloat(property.rentValue?.securityDeposit))}
                      placeholder="Aluguel"
                      _placeholder={{ color: 'gray.500' }}
                      onChange={(e) =>
                        setProperty((state) => {
                          return {
                            ...state,
                            rentValue: { ...state.rentValue!, securityDeposit: e.target.value },
                          };
                        })
                      }
                    />
                  </InputGroup>
                </GridItem>
                <GridItem colSpan={4}>
                  <InputGroup>
                    <Input
                      paddingLeft="10px"
                      bg="gray.100"
                      borderRadius={'md'}
                      variant="flushed"
                      type="text"
                      value={property.rentValue?.leaseDuration ?? ''}
                      placeholder="Aluguel"
                      _placeholder={{ color: 'gray.500' }}
                      onChange={(e) =>
                        setProperty((state) => {
                          return {
                            ...state,
                            rentValue: { ...state.rentValue!, leaseDuration: e.target.value },
                          };
                        })
                      }
                    />
                  </InputGroup>
                </GridItem>
              </Grid>
            </>
          ) : (
            <>
              <Box h="3px" bg={'blackAlpha.100'} marginBottom="8" marginTop="8" />
              <Grid
                h="120px"
                templateRows="repeat(2,1fr)"
                templateColumns="repeat(18, 1fr)"
                gap={4}
              >
                <GridItem rowSpan={2} colSpan={6} textAlign="left">
                  <Box width="min-content">
                    <FaFileInvoiceDollar fontSize="50px" />
                  </Box>
                  <Text fontSize="2xl" flex="1">
                    Venda
                  </Text>
                </GridItem>
                <GridItem colSpan={6}>
                  <Text fontSize="md" flex="1">
                    Valor do imóvel
                  </Text>
                </GridItem>
                <GridItem colSpan={6}>
                  <Text fontSize="md" flex="1">
                    Valor do Adiantamento
                  </Text>
                </GridItem>
                <GridItem colSpan={6}>
                  <InputGroup>
                    <InputLeftElement pointerEvents="none" color="gray.300" fontSize="1.2em" />
                    <Input
                      bg="gray.100"
                      borderRadius={'md'}
                      variant="flushed"
                      type="text"
                      value={formatBrlPrice(stringToFloat(property.sellValue?.value))}
                      placeholder="Aluguel"
                      _placeholder={{ color: 'gray.500' }}
                      onChange={(e) =>
                        setProperty((state) => {
                          return {
                            ...state,
                            sellValue: { ...state.sellValue!, value: e.target.value },
                          };
                        })
                      }
                    />
                  </InputGroup>
                </GridItem>
                <GridItem colSpan={6}>
                  <InputGroup>
                    <InputLeftElement pointerEvents="none" color="gray.300" fontSize="1.2em" />
                    <Input
                      bg="gray.100"
                      borderRadius={'md'}
                      variant="flushed"
                      type="text"
                      value={formatBrlPrice(stringToFloat(property.sellValue?.securityDeposit))}
                      placeholder="Aluguel"
                      _placeholder={{ color: 'gray.500' }}
                      onChange={(e) =>
                        setProperty((state) => {
                          return {
                            ...state,
                            sellValue: { ...state.sellValue!, securityDeposit: e.target.value },
                          };
                        })
                      }
                    />
                  </InputGroup>
                </GridItem>
              </Grid>
            </>
          )}
          <Box h="3px" bg={'blackAlpha.100'} marginBottom="8" marginTop="8" />
          <Grid h="300px" templateRows="repeat(6,1fr)" templateColumns="repeat(18, 1fr)" gap={4}>
            <GridItem rowSpan={6} colSpan={6} textAlign="left">
              <Box width="min-content">
                <FaTree fontSize="50px" />
              </Box>
              <Text fontSize="2xl" flex="1">
                Facilidades
              </Text>
            </GridItem>

            {amenitiesState.map((amenity, index) => {
              return (
                <GridItem key={index} colSpan={3} overflow="hidden">
                  <Checkbox
                    width="sm"
                    colorScheme="green"
                    borderColor="gray.500"
                    textAlign={'left'}
                    defaultChecked={amenity.value}
                    onChange={(e) => {
                      setAmenitiesState((state) => {
                        return state.map((item) => {
                          if (item.name === amenity.name) {
                            return { ...item, value: e.target.checked };
                          }
                          return item;
                        });
                      });
                    }}
                  >
                    {amenity.name}
                  </Checkbox>
                </GridItem>
              );
            })}
          </Grid>
          <Box h="3px" bg={'blackAlpha.100'} marginBottom="8" marginTop="8" />
          <Grid h="360px" templateRows="repeat(2,1fr)" templateColumns="repeat(18, 1fr)" gap={4}>
            <GridItem rowSpan={6} colSpan={6} textAlign="left">
              <Box width="min-content">
                <FaCamera fontSize="50px" />
              </Box>
              <Text fontSize="2xl" flex="1">
                Sobre o imóvel
              </Text>
            </GridItem>
            <GridItem colSpan={12}>
              <Text fontSize="md" flex="1">
                Descrição do imóvel
              </Text>
            </GridItem>
            <GridItem colSpan={12}>
              <InputGroup>
                <Input
                  bg="gray.100"
                  variant="flushed"
                  value={property.description}
                  placeholder="Descrição do imóvel"
                  borderRadius={'md'}
                  _placeholder={{ color: 'gray.500', paddingLeft: '2' }}
                  onChange={(e) =>
                    setProperty((state) => {
                      return {
                        ...state,
                        description: e.target.value,
                      };
                    })
                  }
                />
              </InputGroup>
            </GridItem>
            <GridItem colSpan={12}>
              <Text fontSize="md" flex="1">
                Imagem principal do imóvel
              </Text>
            </GridItem>
            <GridItem colSpan={12}>
              <InputGroup>
                <Input
                  bg="gray.100"
                  variant="flushed"
                  value={property.imageBase64}
                  placeholder="Link para a imagem"
                  borderRadius={'md'}
                  _placeholder={{ color: 'gray.500', paddingLeft: '2' }}
                  onChange={() =>
                    setProperty((state) => {
                      return {
                        ...state,
                      };
                    })
                  }
                />
              </InputGroup>
              <Box p={'2'} alignContent="start"></Box>
            </GridItem>
          </Grid>
        </Box>
        <Button marginBottom="5" colorScheme="green" variant="solid" onClick={handleSubmit}>
          <Box paddingRight="8px">Adicionar Imóvel</Box> <FaDollarSign />
        </Button>
      </Container>
    </>
  );
};

export default NewProperty;
