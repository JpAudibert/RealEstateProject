import { Badge, Box, Button } from '@chakra-ui/react';
import { subDays } from 'date-fns';
import Image from 'next/image';
import router from 'next/router';
import React from 'react';
import { Property } from '../../domain/property';
import { formatBrlPrice } from '../../domain/formatPrice';

interface PropertyCardProps extends Property {
  commercialType: string;
}

const PropertyCard: React.FC<PropertyCardProps> = ({
  id,
  imageBase64,
  city,
  bedrooms,
  bathrooms,
  commercialType: type,
  title: name,
  price,
  dateAdded,
}) => {
  const stringBedrooms = bedrooms === 1 ? 'quatro' : 'quatros';
  const stringBathrooms = bathrooms === 1 ? 'banheiro' : 'banheiros';
  const formattedPrice = formatBrlPrice(price);

  const handleViewDetails = () => {
    router.push(`/property/${id}`);
  };

  return (
    <Box
      margin={3}
      maxW="sm"
      flexGrow={1}
      width="400px"
      borderWidth="1px"
      borderRadius="lg"
      overflow="auto"
      key={id}
      bg="gray.100"
    >
      <Box position="relative">
        {dateAdded >= subDays(new Date(), 7) && (
          <Badge
            borderRadius="full"
            colorScheme="teal"
            mr={2}
            pr="5px"
            pl="5px"
            zIndex="1"
            position="absolute"
            top="5%"
            left="3%"
          >
            New
          </Badge>
        )}
        <Image src={imageBase64} alt={''} height={230} width={400} />
      </Box>

      <Box p="6">
        <Box alignItems="baseline">
          <Box
            color="gray.500"
            fontWeight="semibold"
            letterSpacing="wide"
            fontSize="xs"
            textTransform="uppercase"
          >
            {bedrooms} {stringBedrooms} &bull; {bathrooms} {stringBathrooms} &bull; {type} &bull;{' '}
            {city}
          </Box>
        </Box>
        <Box mt="1" fontWeight="semibold" as="h4" lineHeight="tight" noOfLines={1}>
          {name}
        </Box>
        <Box>
          {formattedPrice}
          <Box as="span" color="gray.600" fontSize="sm">
            {type === 'Aluguel' ? '/dia' : ''}
          </Box>
          <Button
            colorScheme="teal"
            variant="outline"
            size="sm"
            float="right"
            onClick={handleViewDetails}
          >
            Ver detalhes
          </Button>
        </Box>
      </Box>
    </Box>
  );
};

export default PropertyCard;
