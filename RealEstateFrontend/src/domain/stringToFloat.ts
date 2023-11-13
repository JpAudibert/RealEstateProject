const stringToFloat = (str: string | undefined): number => {
  if (str) {
    return Number.parseFloat(str.replace(/\D/g, '') ?? '') / 100;
  }
  return 0;
};

export default stringToFloat;
