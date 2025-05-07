import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";

const CharacterServerTable = () => {
  return (
    <Table>
      <TableHeader>
        <TableRow>
          <TableHead>Server</TableHead>
          <TableHead>Address</TableHead>
          <TableHead>Players</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        <TableRow>
          <TableCell className="font-medium">Poring</TableCell>
          <TableCell>hello.world:5566</TableCell>
          <TableCell>1234</TableCell>
        </TableRow>
      </TableBody>
    </Table>
  );
};

export default CharacterServerTable;
