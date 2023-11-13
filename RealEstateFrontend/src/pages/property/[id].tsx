import React, { useEffect, useMemo, useState } from 'react';

import { FaBath, FaBed, FaCar, FaSquare } from 'react-icons/fa';
import Head from 'next/head';
import { Carousel } from 'react-responsive-carousel';
import { useRouter } from 'next/router';
import { Badge, Box, Button, Flex, Image } from '@chakra-ui/react';
import 'react-responsive-carousel/lib/styles/carousel.min.css';

import SidebarWithHeader from '../../components/SideBar';
import { getHouseData } from '../../domain/getListData';
import { INITITAL_PROPERTY_STATE, Property } from '../../domain/property';
import { formatBrlPrice } from '../../domain/formatPrice';

const Details: React.FC = () => {
  const [property, setProperty] = useState<Property>(INITITAL_PROPERTY_STATE);

  const router = useRouter();

  const id = parseInt(router.query.id as string, 10);

  useEffect(() => {
    const getProperty = async () => {
      const data = await getHouseData(id);
      setProperty(data);
    };

    getProperty();
  }, [setProperty, id]);

  const formattedPrice = useMemo(
    () => formatBrlPrice(property?.price)?.concat(property?.leaseValue ? ' /mês' : ''),
    [property],
  );

  return (
    <SidebarWithHeader>
      <Head>
        <title>Detalhes do imóvel</title>
      </Head>
      <Box>
        <Box
          textAlign="center"
          fontSize="5xl"
          mt="1"
          fontWeight="semibold"
          as="h4"
          lineHeight="tight"
          noOfLines={1}
        >
          {property?.name}
        </Box>
      </Box>
      <Flex justifyContent="space-evenly">
        <Box height="400px" maxWidth="600px" p="5">
          <Carousel>
            {property?.images?.map((image, i) => {
              return (
                <Image
                  key={i}
                  borderRadius="8px"
                  src={image.url}
                  alt={image.alt}
                  height="400px"
                  maxWidth="600px"
                />
              );
            })}
          </Carousel>
        </Box>
        <Flex flexDir="column" mt="1.25rem">
          <Box>
            <Box textAlign="center" fontSize="3xl" fontWeight="semibold">
              {`${property?.address}, ${property?.number} - ${property?.state} - ${property?.city}`}
            </Box>

            <Box textAlign="center" maxW="400px" fontSize="1xl">
              {property?.description}
            </Box>

            <Flex flexDir="row" justifyContent="space-around">
              <Box alignItems="center" fontSize="2xl" p="2">
                <Box>
                  <Flex flexDir="row" alignItems="center" justifyContent="center">
                    <FaBed />
                    <Box pl="1rem">{property?.bedrooms} quartos</Box>
                  </Flex>
                </Box>

                <Box textAlign="center" fontSize="2xl">
                  <Flex flexDir="row" alignItems="center" justifyContent="center">
                    <FaBath />
                    <Box pl="1rem">{property?.bathrooms} banheiros</Box>
                  </Flex>
                </Box>
              </Box>

              <Box textAlign="center" fontSize="2xl" p="2">
                <Flex flexDir="row" alignItems="center" justifyContent="center">
                  <FaSquare />
                  <Box pl="1rem">{property?.squareFeet} m²</Box>
                </Flex>

                <Flex flexDir="row" alignItems="center" justifyContent="center">
                  <FaCar />
                  <Box pl="1rem">{property?.garage} vagas</Box>
                </Flex>
              </Box>
            </Flex>
          </Box>

          <Box p="5">
            <Box maxW="400px">
              {property?.amenities?.map((amenity) => {
                return (
                  <Badge
                    key={amenity.name}
                    borderRadius="3"
                    textTransform="uppercase"
                    colorScheme="teal"
                    fontWeight="bold"
                    mr={2}
                    ps="5px"
                    mt="5px"
                    fontSize="xs"
                  >
                    {amenity.name}
                  </Badge>
                );
              })}
            </Box>
            <Box
              textAlign="center"
              fontSize="2xl"
              mt="5rem"
              fontWeight="semibold"
              as="h4"
              lineHeight="tight"
              noOfLines={1}
            >
              <div>
                {formattedPrice}
                <Button
                  colorScheme="teal"
                  variant="solid"
                  size="sm"
                  ml="4"
                  onClick={() => {
                    console.log('oi');
                    router.push('/devs');
                  }}
                >
                  Entre em contato
                </Button>
              </div>
            </Box>
          </Box>
        </Flex>
      </Flex>
    </SidebarWithHeader>
  );
};

export default Details;
