import React, { useCallback, useEffect, useState } from 'react';
import { Box, Button, Container, Input, Stack } from '@chakra-ui/react';
import { getListData } from '../../domain/getListData';
import { Property } from '../../domain/property';
import PropertyCard from '../PropertyCard/PropertyCard';

const ListCard: React.FC = () => {
  const [list, setList] = useState<Property[]>([]);
  const [search, setSearch] = useState<string>('');
  const [loadingForSale, setLoadingForSale] = useState<boolean>(false);
  const [loadingForRent, setLoadingForRent] = useState<boolean>(true);
  const [type, setType] = useState<string>('Aluguel');

  const handleSearch = useCallback(async () => {
    const list = await getListData(type, search);
    const finalList = list.map((item) => {
      return {
        ...item,
        price: Number(item.sellValue ? item.sellValue.value : item.rentValue?.rent),
      };
    });
    setList(finalList);
  }, [type, search]);

  const handleSearchForRent = useCallback(async () => {
    setType('Aluguel');
    setLoadingForRent(true);
    handleSearch();
    setLoadingForRent(false);
  }, [handleSearch]);

  const handleSearchForSale = useCallback(async () => {
    setType('Venda');
    setLoadingForSale(true);
    handleSearch();
    setLoadingForSale(false);
  }, [handleSearch]);

  useEffect(() => {
    handleSearchForRent();
  }, [handleSearchForRent]);

  return (
    <Container borderWidth="1px" maxW="container.xl" backgroundColor="gray.200" borderRadius="lg">
      <Stack justifyContent="center" direction="row" spacing={4} mt={5}>
        <Input
          bg={'blackAlpha.100'}
          placeholder="Pesquisar"
          value={search}
          onChange={(e) => {
            setSearch(e.target.value);
            handleSearch();
          }}
        />
        <Button
          isLoading={loadingForRent}
          colorScheme="blue"
          onClick={handleSearchForRent}
          variant="solid"
        >
          Para alugar
        </Button>
        <Button
          isLoading={loadingForSale}
          colorScheme="blue"
          onClick={handleSearchForSale}
          variant="solid"
        >
          Para comprar
        </Button>
      </Stack>

      {loadingForSale || loadingForRent ? (
        <Box mt={5} textAlign="center">
          Carregando...
        </Box>
      ) : (
        <Box display="flex" flexWrap="wrap" justifyContent="center">
          {list.map((item) => (
            <PropertyCard {...item} key={item.id} />
          ))}
        </Box>
      )}
    </Container>
  );
};

export default ListCard;
