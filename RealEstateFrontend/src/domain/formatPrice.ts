export const formatBrlPrice = (price: number | undefined): string | undefined => {
  return price?.toLocaleString('pt-BR', {
    style: 'currency',
    currency: 'BRL',
  });
};
