import React, { useCallback, useRef } from 'react';

import {
  Button,
  FormControl,
  FormLabel,
  Input,
  Modal,
  ModalBody,
  ModalCloseButton,
  ModalContent,
  ModalFooter,
  ModalHeader,
  ModalOverlay,
  Textarea,
} from '@chakra-ui/react';

interface ContactUsModalProps {
  isOpen: boolean;
  onClose: () => void;
}

const ContactUsModal: React.FC<ContactUsModalProps> = ({ isOpen, onClose }) => {
  const initialRef = useRef(null);

  const handleSubmit = useCallback(() => {
    console.log('submit');
    onClose();
  }, [onClose]);

  return (
    <form onSubmit={handleSubmit}>
      <Modal initialFocusRef={initialRef} isOpen={isOpen} onClose={onClose}>
        <ModalOverlay />
        <ModalContent>
          <ModalHeader>Entre em Contato</ModalHeader>
          <ModalCloseButton />
          <ModalBody pb={6}>
            <FormControl isRequired>
              <FormLabel>Nome Completo</FormLabel>
              <Input ref={initialRef} placeholder="Nome Completo" />
            </FormControl>

            <FormControl mt={4} isRequired>
              <FormLabel>Email</FormLabel>
              <Input placeholder="Email" inputMode="email" />
            </FormControl>

            <FormControl mt={4} isRequired>
              <FormLabel>Mensagem</FormLabel>
              <Textarea placeholder="Mensagem" />
            </FormControl>
          </ModalBody>

          <ModalFooter>
            <Button colorScheme="blue" mr={3} type="submit">
              Enviar
            </Button>
            <Button onClick={onClose}>Cancelar</Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </form>
  );
};

export default ContactUsModal;
