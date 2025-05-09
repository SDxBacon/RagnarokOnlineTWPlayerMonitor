import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";

import { ragnarok } from "../../wailsjs/go/models";

interface CharacterServerTableProps {
  data: ragnarok.CharacterServerInfo[];
}

const CharacterServerTable = (props: CharacterServerTableProps) => {
  const { data } = props;

  return (
    <Table className="bg-[var(--accent)] h-[225px]">
      <TableHeader className="bg-[var(--chart-5)]">
        <TableRow>
          <TableHead>Server</TableHead>
          <TableHead>Address</TableHead>
          <TableHead>Players</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        {data.map((item, index) => (
          <TableRow key={index}>
            <TableCell className="font-medium">{item.Name}</TableCell>
            <TableCell>{item.Url}</TableCell>
            <TableCell>{item.Players}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
};

export default CharacterServerTable;
